
using Ejemplo_15_personas_datoslib.Models;
using Ejemplo_15_personas_datoslib.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ejemplo_04_0_Roles_Login.Controllers;


[Authorize(Roles = "Admin")]
public class PersonasController : Controller
{
    readonly private PersonasService _personasService;

    public PersonasController(PersonasService personaService)
    {
        _personasService = personaService;
    }

    // GET: PersonasController
    [HttpGet]
    async public Task<IActionResult> Index()
    {
        return View(await _personasService.GetAll());
    }

    // GET: PruebaController1/Details/5
    [HttpGet]
    async public Task<IActionResult> Details(int id)
    {
        var persona = await _personasService.GetById(id);
        return View(persona);
    }

    // GET: PruebaController1/Create
    [HttpGet]
    async public Task<IActionResult> Create()
    {
        return View();
    }

    // POST: PruebaController1/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    //https://learn.microsoft.com/es-es/aspnet/core/security/anti-request-forgery?view=aspnetcore-9.0
    // http://go.microsoft.com/fwlink/?LinkId=317598
    async public Task<IActionResult> Create(PersonaModel nuevo)
    {
        try
        {
            await _personasService.CrearNuevo(nuevo);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: PersonaController1/Edit/5
    //http://localhost:5033/Personas/Edit/1
    [HttpGet]
    async public Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return BadRequest();

        var persona = await _personasService.GetById(Convert.ToInt32(id));
        return View(persona);
    }

    // POST: PersonaController/Edit/1
    [HttpPost]
    [ValidateAntiForgeryToken]
    async public Task<IActionResult> Edit(int id, PersonaModel persona)
    {
        if (id != persona.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                await _personasService.Actualizar(persona);
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
    async public Task<IActionResult> Delete(int? id)
    {
        if (id == null || id <= 0)
            return BadRequest();

        var persona = await _personasService.GetById(Convert.ToInt32(id));

        if (persona == null)
            return NotFound();

        return View(persona);
    }

    // POST: PruebaController1/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    async public Task<IActionResult> Delete(int? id, PersonaModel persona)
    {
        if (id == null || id <= 0)
            return BadRequest();

        try
        {
            if (_personasService.GetById(Convert.ToInt32(id)) == null)
                return NotFound();

            await _personasService.Eliminar(Convert.ToInt32(id));

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return RedirectToAction("Delete", new { id = id, saveChangesError = true });
        }
    }
}
