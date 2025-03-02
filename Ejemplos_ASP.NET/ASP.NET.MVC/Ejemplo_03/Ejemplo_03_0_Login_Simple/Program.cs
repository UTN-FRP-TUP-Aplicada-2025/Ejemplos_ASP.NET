
using Ejemplo_15_personas_datoslib.DALs.MSSDALs;
using Ejemplo_15_personas_datoslib.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region creando el contexto
builder.Services.AddSingleton<PersonasMSSDAL>();
builder.Services.AddSingleton<UsuariosMSSDAL>();
builder.Services.AddSingleton<RolesMSSDAL>();
builder.Services.AddSingleton<UsuariosRolesMSSDAL>();
//
builder.Services.AddSingleton<PersonasService>();
builder.Services.AddSingleton<CuentasService>();
builder.Services.AddSingleton<RolesService>();
//
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
app.UseAuthentication(); //middleware para la autenticación
app.UseAuthorization();  //middleware para la autorización
app.UseSession();        //middleware para la sesión
#endregion

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
