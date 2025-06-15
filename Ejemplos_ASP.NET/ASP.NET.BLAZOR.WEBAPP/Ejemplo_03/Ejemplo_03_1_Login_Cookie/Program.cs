using Ejemplo_03_1_Login_Cookie;
using Ejemplo_03_1_Login_Cookie.Components;
using Ejemplo_03_1_Login_Cookie.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<UsuariosService>(); // Asegúrate de que tu servicio esté registrado

builder.Services.AddScoped<PasswordHasher<ApplicationUser>>();

//builder.Services.AddIdentityCore<ApplicationUser>() // Usa AddIdentityCore para un registro más básico
//    .AddUserStore<CustomUserStore>()
//    .AddSignInManager<SignInManager<ApplicationUser>>();


#region login - esquema de autentificación por cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => {
        options.Cookie.Name = "auth_token";
        options.LoginPath = "/login";
        options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
        options.AccessDeniedPath = "/access-denied";
    });
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
//necesario para acceder al contexto httpcontext
builder.Services.AddHttpContextAccessor();
#endregion

// Registro de Identity con tu CustomUserStore y PasswordHasher
builder.Services.AddScoped<PasswordHasher<ApplicationUser>>();
builder.Services.AddScoped<UsuariosService>();
builder.Services.AddIdentityCore<ApplicationUser>().AddUserStore<CustomUserStore>();

// Configuración del esquema de cookies para Identity
builder.Services.AddAuthentication()
    .AddCookie("Identity.Application", options =>
    {
        options.Cookie.Name = "Identity.Application";
        options.LoginPath = "/login";
        // Otras opciones de cookie si es necesario
    });

builder.Services.AddScoped<SignInManager<ApplicationUser>>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

// Mapear los componentes Razor
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();