using Ejemplo_03_0_Login_Simple.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ejemplo_03_0_Login_Simple.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IDataProtectionProvider _dataProtectionProvider;

    public HomeController(ILogger<HomeController> logger, IDataProtectionProvider dataProtectionProvider)
    {
        _logger = logger;
        _dataProtectionProvider = dataProtectionProvider;
    }

    public IActionResult Index()
    {
        #region inspeccionando la cookie generada
        var cookieValue = Request.Cookies["Cookie_authenticacion"];
        if (string.IsNullOrEmpty(cookieValue) == false)
        {

            // Configura el protector
            var protector = _dataProtectionProvider.CreateProtector(
                "Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationMiddleware",
                "Cookies",
                "v2"
            );

            // Usa el protector para desproteger la cookie
            var ticketFormat = new TicketDataFormat(protector);
            try
            {
                //muestra el contenido de la cookie
                var ticket = ticketFormat.Unprotect(cookieValue);
                _logger.LogTrace($"Usuario autenticado: {ticket?.Principal?.Identity?.Name}");
            }
            catch (Exception ex)
            {
                _logger.LogTrace($"Error al desproteger la cookie: {ex.Message}");
            }
        }
        #endregion

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
