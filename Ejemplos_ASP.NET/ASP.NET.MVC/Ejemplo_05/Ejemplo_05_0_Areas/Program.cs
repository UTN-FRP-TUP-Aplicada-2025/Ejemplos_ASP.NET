using Ejemplo_15_personas_datoslib.DALs;
using Ejemplo_15_personas_datoslib.DALs.MSSDALs;
using Ejemplo_15_personas_datoslib.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

using Microsoft.AspNetCore.HttpOverrides; // <-- Importante

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

#region creando el contexto
builder.Services.AddTransient<SqlConnection>(sp =>
{
    var configuration = sp.GetService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("CadenaConexion");
    return new SqlConnection(connectionString);
});

//La conexion se mantiene viva solo durante la duracion de una solicitud HTTP.
//Es mas eficiente en aplicaciones con multiples solicitudes simultaneas.
builder.Services.AddScoped<ITransaction<SqlTransaction>, SqlServerTransaction>();

builder.Services.AddScoped<PersonasMSSDAL>();
builder.Services.AddScoped<UsuariosMSSDAL>();
builder.Services.AddScoped<RolesMSSDAL>();
builder.Services.AddScoped<UsuariosRolesMSSDAL>();
//
builder.Services.AddScoped<PersonasService>();
builder.Services.AddScoped<CuentasService>();
builder.Services.AddScoped<RolesService>();
#endregion

#region configuracion de restapi y swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(); //este alcanza si solo es restapi
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Ejemplo API",
        Version = "v1"
    });

    //para filtrar los controladores que fueron tagueados con el atributo: [ApiController]
    //sino mapea los controladores de la vista
    c.DocInclusionPredicate((docName, apiDesc) =>
    {
        var controllerActionDescriptor = apiDesc.ActionDescriptor as Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor;
        return controllerActionDescriptor != null &&
               controllerActionDescriptor.ControllerTypeInfo.GetCustomAttributes(typeof(ApiControllerAttribute), true).Any();
    });
});
#endregion


#region manejo de sesion

builder.Services.AddAuthentication("Cookies")
    .AddCookie(options =>
    {
        options.LoginPath = "/Cuentas/Login";
        options.LogoutPath = "/Cuentas/Logout";
        options.Cookie.Name = "Cookie_authenticacion";
        options.Cookie.MaxAge = TimeSpan.FromMinutes(1);
    });

builder.Services.AddAuthorization();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.Name = "Cookie_session";
});

#endregion

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

#region area
app.MapAreaControllerRoute(
    name: "Admin_default",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "Users_default",
    areaName: "User",
    pattern: "User/{controller=Home}/{action=Index}/{id?}");
#endregion 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

#region configuracion api y swagger
//if (app.Environment.IsDevelopment()) //comentar para que corra en modo release
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
#endregion

#region habilitando middleware adicionales
app.UseAuthentication(); //middleware para la autenticacion
app.UseAuthorization();  //middleware para la autorizacion
app.UseSession();        //middleware para la sesion
#endregion

#region proxy docker
//configuración encabezados proxy inverso
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});
// Configurar redirección HTTPS
app.UseHttpsRedirection();
#endregion

app.Run();







