using EjemploASP.NET_MVC.Models;
using EjemploASP.NET_MVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EjemploASP.NET_MVC.Controllers;

public class PersonasController : Controller
{
    private PersonasService servicio = new PersonasService();

    // GET: PersonasController
    public IActionResult Index()
    {
        return View(servicio.GetAll());
    }

    // GET: PersonaController1/Edit/5
    //http://localhost:5033/Personas/Editar/1
    [HttpGet]
    public IActionResult Editar(int id)
    {
        return View(servicio.GetById(id));
    }

    // POST: PersonaController/Edit/1
    [HttpPost]
    public ActionResult Editar(int id, Persona persona)
    {
        try
        {
                servicio.Actualizar(persona);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
