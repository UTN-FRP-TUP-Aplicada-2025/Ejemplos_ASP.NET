using Ejemplo_03_CRUD_Simple_Login.Security;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

#region configurando el identity

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 3;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
.AddRoles<IdentityRole>() 
.AddSignInManager<SignInManager<IdentityUser>>() 
.AddUserStore<InDALUserStore>() 
.AddRoleStore<InDALRoleStore>()
.AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

builder.Services.AddMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Configurar tiempo de expiraci�n
    options.Cookie.HttpOnly = true;                // Reforzar seguridad de cookies
    options.Cookie.IsEssential = true;             // Obligatorio para cumplir RGPD
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Cuenta/Login";
    options.AccessDeniedPath = "/Cuenta/AccesoDenegado";
});

#endregion

var app = builder.Build();

#region preinicializacion aplicacion
var scope = app.Services.CreateScope();

var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

if (!await roleManager.RoleExistsAsync("Admin"))
{
    await roleManager.CreateAsync(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });
}

if (!await roleManager.RoleExistsAsync("User"))
{
    await roleManager.CreateAsync(new IdentityRole { Name = "User", NormalizedName = "USER" });
}

var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
var adminUser = await userManager.FindByNameAsync("admin");
if (adminUser == null)
{
    var user = new IdentityUser { UserName = "admin", Email = "admin@example.com" };
    var result = await userManager.CreateAsync(user, "123"); //va a hashear ese 123

    if (result.Succeeded)
    {
        await userManager.AddToRoleAsync(user, "Admin");
    }
}
#endregion

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

#region habilitando session
app.UseAuthorization();
app.UseSession();
#endregion

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
