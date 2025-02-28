using Ejemplo_01_0_CRUD_MVC_Simple.DALs.MSSDALs;
using Microsoft.AspNetCore.Mvc;

namespace Ejemplo_01_CRUD_MVC_Simple.Controllers;

public class RolesController : Controller
{
    RolesMSSDAL _rolesDao = new RolesMSSDAL();

    async public Task<IActionResult> Index()
    {
        return View(await _rolesDao.GetAll());
    }
}
