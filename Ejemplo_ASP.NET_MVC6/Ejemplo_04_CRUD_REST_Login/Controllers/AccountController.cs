using Ejemplo_04_CRUD_REST_Login.Models;
using Ejemplo_04_CRUD_REST_Login.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ejemplo_04_CRUD_REST_Login.Controllers;

[Authorize]
public class AccountController : Controller
{
    UsuariosService _service = new UsuariosService();

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
    public async Task<IActionResult> Login(UsuarioModel usuario, string returnUrl = "/")
    {

        var result = _service.VerificarLogin(usuario);

        if (usuario == null)
        {
            ModelState.AddModelError("", "Usuario o contraseña no válidos.");
            return View();
        }
      
        var claims = new List<Claim>()
        {
             new Claim(ClaimTypes.Name, usuario.Nombre),
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
