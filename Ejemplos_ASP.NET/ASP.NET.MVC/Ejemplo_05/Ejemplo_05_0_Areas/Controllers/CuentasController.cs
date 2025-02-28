
using Ejemplo_05_Areas.Models;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using Ejemplo_05_0_Integracion.Services;

namespace Ejemplo_05_Areas.Controllers;

[Authorize]
public class CuentasController : Controller
{
    CuentasService _usuariosService = new CuentasService();

    private readonly ILogger<CuentasController> _logger;

    public CuentasController(ILogger<CuentasController> logger)
    {
        _logger = logger;
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

        if (result==false)
        {
            ModelState.AddModelError("", "Usuario o contraseña no válidos.");
            return View();
        }

        var roles=await _usuariosService.GetRolesByUsuario(usuario.Nombre);

        var claims = new List<Claim>()
        {
             new Claim(ClaimTypes.Name, usuario.Nombre)
        };

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
