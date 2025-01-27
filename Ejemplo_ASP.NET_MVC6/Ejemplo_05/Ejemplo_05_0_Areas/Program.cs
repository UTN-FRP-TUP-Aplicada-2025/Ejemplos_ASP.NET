var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

#region area
app.MapAreaControllerRoute(
    name: "Admin_default",
    areaName: "Admin",
    pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "Users_default",
    areaName: "Users",
    pattern: "Users/{controller=Perfil}/{action=Index}/{id?}");
#endregion 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
