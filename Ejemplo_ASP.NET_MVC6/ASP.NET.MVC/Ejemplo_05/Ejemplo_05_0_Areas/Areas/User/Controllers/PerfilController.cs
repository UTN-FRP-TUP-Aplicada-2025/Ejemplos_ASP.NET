using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ejemplo_05_Areas.Areas.User.Controllers;

[Area("User")]
//[Authorize(Roles = "User")]
public class PerfilController : Controller
{
    // GET: PerfilController
    public ActionResult Index()
    {
        return View();
    }
    
}
