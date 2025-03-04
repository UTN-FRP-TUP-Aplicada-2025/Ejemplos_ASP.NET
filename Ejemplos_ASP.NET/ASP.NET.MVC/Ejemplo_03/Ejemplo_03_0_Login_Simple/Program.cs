
using Ejemplo_15_personas_datoslib.DALs;
using Ejemplo_15_personas_datoslib.DALs.MSSDALs;
using Ejemplo_15_personas_datoslib.Services;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

//proxy github
//builder.WebHost.UseUrls("http://0.0.0.0:8080");

// Add services to the container.
builder.Services.AddControllersWithViews();

#region creando el contexto
builder.Services.AddTransient<SqlConnection>(sp =>
{
    var configuration = sp.GetService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("CadenaConexion");
    return new SqlConnection(connectionString);
});

//La conexi�n se mantiene viva solo durante la duraci�n de una solicitud HTTP.
//Es m�s eficiente en aplicaciones con m�ltiples solicitudes simult�neas.
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

#region identidad

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

builder.Services.AddDataProtection();

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

#region habilitando middleware adicionales
app.UseAuthentication(); //middleware para la autenticaci�n
app.UseAuthorization();  //middleware para la autorizaci�n
app.UseSession();        //middleware para la sesi�n
#endregion

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
