using Ejemplo_03_0_Login_Simple.Components;

using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication("Cookies")
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.Cookie.Name = "Cookie_authenticacion";
        options.Cookie.MaxAge = TimeSpan.FromMinutes(1);
    });

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Agregar Razor Runtime Compilation (para cambios en vistas sin recompilar)
builder.Services.Configure<MvcRazorRuntimeCompilationOptions>(options =>
{
    options.FileProviders.Add(new Microsoft.Extensions.FileProviders.PhysicalFileProvider(
        builder.Environment.ContentRootPath));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

#region habilitando middleware adicionales
app.UseAuthentication(); //middleware para la autenticación
app.UseAuthorization();  //middleware para la autorización
app.UseSession();        //middleware para la sesión
#endregion

app.Run();
