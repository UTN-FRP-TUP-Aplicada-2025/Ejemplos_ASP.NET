using Ejemplo_15_personas_datoslib.DALs.MSSDALs;
using Microsoft.AspNetCore.Mvc;

namespace Ejemplo_01_CRUD_MVC_Simple.Controllers;

public class RolesController : Controller
{
    private RolesMSSDAL _rolesDao;

    public RolesController(RolesMSSDAL rolesDao)
    {
        _rolesDao= rolesDao;
    }

    async public Task<IActionResult> Index()
    {
        return View(await _rolesDao.GetAll());
    }
}
