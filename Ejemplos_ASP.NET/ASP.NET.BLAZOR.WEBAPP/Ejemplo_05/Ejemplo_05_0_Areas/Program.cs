using Ejemplo_05_0_Areas.Components;
using Ejemplo_05_0_Areas.Components.Layout;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;


var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "auth_token";
        options.LoginPath = "/admin/login";
        options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
        options.AccessDeniedPath = "/admin/access-denied";
        options.ReturnUrlParameter = "returnurl";
    });
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
//necesario para acceder al contexto httpcontext
builder.Services.AddHttpContextAccessor();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(
//        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "admin")),
//    RequestPath = "/admin/assets"
//});

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

//app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

//app.MapWhen(context => context.Request.Path.StartsWithSegments("/admin"), adminApp =>
//{
//    adminApp.UseRouting();
//    adminApp.UseEndpoints(endpoints =>
//    {
//        endpoints.MapRazorComponents<App>()
//                 .AddInteractiveServerRenderMode();
//    });
//});


// Mapear los componentes Razor
//e habilita la renderización interactiva con SignalR, permitiendo que Blazor Server maneje la UI en el servidor.
//En Blazor Server, la lógica del componente se ejecuta en el servidor y se mantiene una conexión en tiempo real con el cliente a través de SignalR.
//Los eventos en la UI (clics, cambios en formularios, etc.) se envían al servidor, se procesan y el DOM se actualiza en el navegador.
//Si esta  AddInteractiveServerRenderMode(), Blazor no sabrá cómo manejar la interacción, y solo podrá renderizar componentes estáticos en el HTML inicial, sin eventos ni interactividad.
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
