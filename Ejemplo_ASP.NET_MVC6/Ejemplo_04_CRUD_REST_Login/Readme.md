
## paquetes NuGet

Swagger: `Swashbuckle.AspNetCore`

ADO.NET: `Microsoft.Data.SqlClient`

## Configuración del Startup (Program.cs)

```csharp
builder.Services.AddAuthentication("Cookies")
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
    });

builder.Services.AddAuthorization();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); 
    options.Cookie.HttpOnly = true; 
    options.Cookie.IsEssential = true; 
});
```

```csharp
app.UseAuthorization();
app.UseSession();
```

## Ejemplo de controlador 

```csharp
namespace Ejemplo_04_CRUD_REST_Login.Controllers;

[Authorize]
public class AccountController : Controller
{
    IUsuariosDAL _usuarioDAO = new UsuariosMSSDAL();

    [AllowAnonymous]
    async public Task<ViewResult> Login(string ReturnUrl)
    {
        return View(new UsuarioModel
        {
            ReturnUrl = ReturnUrl
        });
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(UsuarioModel usuarioModel, string returnUrl = "/")
    {
        var usuario=_usuarioDAO.GetByNombre(usuarioModel.Nombre);

        if (usuario == null)
        {
            ModelState.AddModelError("", "Usuario o contraseña inválidos.");
            return View();
        }

        var claveHash = _usuarioDAO.HashPassword(usuarioModel.Clave);
        var result = usuario != null &&  claveHash == usuario.Clave;

        if (result==false)// PasswordVerificationResult.Failed)
        {
            ModelState.AddModelError("", "Usuario o contraseña inválidos.");
            return View();
        }

        var claims = new List<Claim>()
        {
             new Claim(ClaimTypes.Name, usuarioModel.Nombre),
        };

        var identity = new ClaimsIdentity(claims, "Cookies");
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync("Cookies", principal);

        return Redirect(returnUrl);
    }

    public async Task<RedirectResult> Logout(string returnUrl = "/")
    {
        await HttpContext.SignOutAsync();
        return Redirect(returnUrl);
    }
}

```

## Vista asociada al controlador

```html
@model Ejemplo_04_CRUD_REST_Login.Models.UsuarioModel

@{
    ViewBag.Title = "Log In";
    Layout = "_AdminLayout";
}

<div class="container">

    <div class="text-danger" asp-validation-summary="All"></div>

    <div class="row">

        <form asp-action="Login" asp-controller="Account" method="post">

            <input type="hidden" asp-for="ReturnUrl" />

            <div class="form-group">
                <label asp-for="Nombre"></label>
                <div><span asp-validation-for="Nombre" class="text-danger"></span></div>
                <input asp-for="Nombre" class="form-control" />
            </div>

            <div class="form-group">
                <label asp-for="Clave"></label>
                <div><span asp-validation-for="Clave" class="text-danger"></span></div>
                <input asp-for="Clave" class="form-control" />
            </div>

            <button class="btn btn-primary" type="submit">Log In</button>
        </form>

    </div>
</div>

```