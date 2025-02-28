using Ejemplo_03_0_Login_Simple.Models;
using Ejemplo_03_0_Login_Simple.Services;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

namespace Ejemplo_03_0_Login_Simple.Controllers;

[Authorize]
public class CuentasController : Controller
{
    readonly UsuariosService _usuariosService;
    readonly ILogger<HomeController> _logger;

    public CuentasController(ILogger<HomeController> logger, UsuariosService usuariosService)
    {
        _logger = logger;
        _usuariosService = usuariosService;
    }

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
        var result = await _usuariosService.VerificarLogin(usuario);

        //if (usuario == null) error
        if (result==null)
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
