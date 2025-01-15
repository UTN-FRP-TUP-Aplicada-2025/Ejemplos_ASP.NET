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

    // GET: PruebaController1/Details/5
    public ActionResult Details(int id)
    {
        var persona = servicio.GetById(id);
        return View(persona);
    }

    // GET: PruebaController1/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: PruebaController1/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Persona nuevo)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: PersonaController1/Edit/5
    //http://localhost:5033/Personas/Editar/1
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var persona = servicio.GetById(id);
        return View(persona);
    }

    // POST: PersonaController/Edit/1
    [HttpPost]
    public ActionResult Edit(int id, Persona persona)
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

    // GET: PruebaController1/Delete/5
    public ActionResult Delete(int id)
    {
        var persona = servicio.GetById(id);
        return View(persona);
    }

    // POST: PruebaController1/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id,  Persona persona)
    {
        try
        {
            servicio.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
