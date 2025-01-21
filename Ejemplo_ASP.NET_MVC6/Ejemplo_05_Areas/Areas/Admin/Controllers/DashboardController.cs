using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ejemplo_05_Areas.Areas.Admin.Controllers;


[Area("Products")]
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        ViewData["routeInfo"] = ControllerContext.MyDisplayRouteInfo();
        return View();
    }

    public IActionResult About()
    {
        ViewData["routeInfo"] = ControllerContext.MyDisplayRouteInfo();
        return View();
    }
}
