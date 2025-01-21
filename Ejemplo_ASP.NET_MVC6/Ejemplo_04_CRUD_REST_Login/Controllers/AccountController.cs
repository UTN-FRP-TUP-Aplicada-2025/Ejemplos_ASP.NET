using Ejemplo_04_CRUD_REST_Login.DALs;
using Ejemplo_04_CRUD_REST_Login.DALs.MSSDAO;
using Ejemplo_04_CRUD_REST_Login.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Security.Claims;

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
