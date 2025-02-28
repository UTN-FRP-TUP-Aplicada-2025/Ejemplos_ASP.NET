using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ejemplo_05_Areas.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class Home : Controller
{
    // GET: Home
    public ActionResult Index()
    {
        return View();
    }

    
}
