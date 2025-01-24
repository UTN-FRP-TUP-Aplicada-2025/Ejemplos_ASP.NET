using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ejemplo_05_Areas.Areas.Users.Controllers
{
    [Area("Users")]
    public class PerfilController : Controller
    {
        // GET: PerfilController
        public ActionResult Index()
        {
            return View();
        }
        
    }
}
