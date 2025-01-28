using Ejemplo_05_Areas.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Ejemplo_05_Areas.Models;

namespace Ejemplo_05_Areas.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class PersonasController : Controller
{
    private PersonasService servicio = new PersonasService();

    // GET: PersonasController
    [HttpGet]
    public IActionResult Index()
    {
        return View(servicio.GetAll());
    }

    // GET: PruebaController1/Details/5
    [HttpGet]
    public ActionResult Details(int id)
    {
        var persona = servicio.GetById(id);
        return View(persona);
    }

    // GET: PruebaController1/Create
    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }

    // POST: PruebaController1/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    //https://learn.microsoft.com/es-es/aspnet/core/security/anti-request-forgery?view=aspnetcore-9.0
    // http://go.microsoft.com/fwlink/?LinkId=317598
    public ActionResult Create(PersonaModel nuevo)
    {
        try
        {
            servicio.CrearNuevo(nuevo);
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
    public IActionResult Edit(int? id)
    {
        if (id == null)
            return BadRequest();

        var persona = servicio.GetById(Convert.ToInt32(id));
        return View(persona);
    }

    // POST: PersonaController/Edit/1
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, PersonaModel persona)
    {
        if (id != persona.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                servicio.Actualizar(persona);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error");
            }
            return RedirectToAction(nameof(Index));
        }
        return View(persona);
    }

    // GET: PruebaController1/Delete/5
    [HttpGet]
    public ActionResult Delete(int? id)
    {
        if (id == null || id <= 0)
            return BadRequest();

        var persona = servicio.GetById(Convert.ToInt32(id));

        if (persona == null)
            return NotFound();

        return View(persona);
    }

    // POST: PruebaController1/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int? id, PersonaModel persona)
    {
        if (id == null || id <= 0)
            return BadRequest();

        try
        {
            if (servicio.GetById(Convert.ToInt32(id)) == null)
                return NotFound();

            servicio.Eliminar(Convert.ToInt32(id));

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return RedirectToAction("Delete", new { id = id, saveChangesError = true });
        }
    }
}
