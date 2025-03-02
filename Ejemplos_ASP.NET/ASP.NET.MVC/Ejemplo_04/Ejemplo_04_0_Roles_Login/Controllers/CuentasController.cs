using Ejemplo_15_personas_datoslib.Models;
using Ejemplo_15_personas_datoslib.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

namespace Ejemplo_04_0_Roles_Login.Controllers;

[Authorize]
public class CuentasController : Controller
{
    readonly CuentasService _usuariosService;
    readonly ILogger<HomeController> _logger;

    public CuentasController(ILogger<HomeController> logger, CuentasService usuariosService)
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

        var result = _usuariosService.VerificarLogin(usuario);

        if (usuario == null)
        {
            ModelState.AddModelError("", "Usuario o contraseña no válidos.");
            return View();
        }
      
        var claims = new List<Claim>()
        {
             new Claim(ClaimTypes.Name, usuario.Nombre),
        };

        var roles = await _usuariosService.GetRolesByUsuario(usuario.Nombre);
        foreach (var rol in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, rol.NombreRol));
        }

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
