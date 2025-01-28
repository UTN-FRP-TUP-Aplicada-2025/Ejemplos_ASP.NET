using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ejemplo_05_Areas.User.Admin.Controllers;


[Area("User")]
[Authorize(Roles = "User")]
public class Home : Controller
{
    // GET: Home
    public ActionResult Index()
    {
        return View();
    }
}
