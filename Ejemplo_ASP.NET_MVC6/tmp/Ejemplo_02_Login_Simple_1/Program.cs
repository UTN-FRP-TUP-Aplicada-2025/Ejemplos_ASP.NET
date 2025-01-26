using Ejemplo_Login_Simple.Security;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

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
.AddUserStore<InMemoryUserStore>() 
.AddRoleStore<InMemoryRoleStore>() 
.AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

builder.Services.AddMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(1);
    options.Cookie.HttpOnly = true;               
    options.Cookie.IsEssential = true;         
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Cuenta/Login"; 
    options.AccessDeniedPath = "/Cuenta/AccesoDenegado"; 
});

#endregion

var app = builder.Build();

#region preinicialización aplicación
var scope = app.Services.CreateScope() ;

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
    var result=await userManager.CreateAsync(user, "123"); //va a hashear ese 123

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

#region habilitando session
app.UseAuthorization();
app.UseSession();
#endregion

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
