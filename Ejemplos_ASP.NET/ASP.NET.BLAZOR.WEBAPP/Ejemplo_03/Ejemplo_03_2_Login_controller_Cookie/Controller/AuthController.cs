using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//[Route("auth")]
namespace Ejemplo_03_2_Login_controller_Cookie.Controller;

public class AuthController : Controller
{
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Redirect("/"); // Redirigir a la página de inicio
    }
}
