using Ejemplo_03_0_Login_Simple.Components;
using Ejemplo_03_0_Login_Simple.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddAuthentication("Cookies")
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";    // Ruta de login
        options.LogoutPath = "/Account/Logout"; // Ruta de logout
        options.Cookie.Name = "Cookie_authenticacion";
        options.Cookie.MaxAge = TimeSpan.FromMinutes(1);
    });

builder.Services.AddAuthorization();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.Name = "Cookie_session";
});

builder.Services.AddDataProtection();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

#region habilitando middleware adicionales
app.UseAuthentication(); //middleware para la autenticación
app.UseAuthorization();  //middleware para la autorización
app.UseSession();        //middleware para la sesión

#endregion

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
