using Ejemplo_03_2_Login_controller_Cookie.Models;
using Ejemplo_03_2_Login_controller_Cookie.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Security.Claims;

//[Route("auth")]
namespace Ejemplo_03_2_Login_controller_Cookie.Controller;


[Route("auth")]
[ApiController]
public class AuthController : ControllerBase
{

    //private IHttpContextAccessor HttpContextAccessor;

    //public AuthController(IHttpContextAccessor httpContextAccessor)
    //{
    //    HttpContextAccessor = httpContextAccessor;
    //}

    private UsuariosService _usuarioService = new UsuariosService();

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody]UsuarioModel Model)
    {
        if (await _usuarioService.VerificarLogin(Model) == false)
        {
            string errorMessages = " Usuario o Contraseña no válidos!";
            return Ok(errorMessages);
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, Model.Nombre)
        };

        var identity = new ClaimsIdentity(claims, "Cookies");
        var principal = new ClaimsPrincipal(identity);

        // Acceder a HttpContext a través de IHttpContextAccessor
        //var httpContext = HttpContextAccessor.HttpContext;
       // if (httpContext != null)
        {
            await HttpContext.SignInAsync("Cookies", principal);
            return Redirect("/");
        }
       // else
        //{
          //  string errorMessages = "No se pudo iniciar sesión debido a un error interno.";
           // return Ok(errorMessages);
        //}
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Redirect("/"); // Redirigir a la página de inicio
    }
}
