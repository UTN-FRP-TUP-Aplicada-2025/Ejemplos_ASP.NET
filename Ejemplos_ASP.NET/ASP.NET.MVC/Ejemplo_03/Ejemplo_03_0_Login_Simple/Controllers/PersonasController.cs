using Ejemplo_03_0_Login_Simple.Services;
using Ejemplo_03_0_Login_Simple.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ejemplo_03_0_Login_Simple.Controllers;

[Authorize]
public class PersonasController : Controller
{
    private readonly PersonasService _serviciosService;

    public PersonasController(PersonasService serviciosService)
    {
        _serviciosService = serviciosService;
    }

    // GET: PersonasController
    [HttpGet]
    async public Task<IActionResult> Index()
    {
        return View(await _serviciosService.GetAll());
    }

    // GET: PruebaController1/Details/5
    [HttpGet]
    async public Task<IActionResult> Details(int id)
    {
        var persona = await _serviciosService.GetById(id);
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
            await _serviciosService.CrearNuevo(nuevo);
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
    async public Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return BadRequest();

        var persona = await _serviciosService.GetById(Convert.ToInt32(id));
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
                await _serviciosService.Actualizar(persona);
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

        var persona = await _serviciosService.GetById(Convert.ToInt32(id));
        
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
            if (await _serviciosService.GetById(Convert.ToInt32(id)) == null)
                return NotFound();

            await _serviciosService.Eliminar(Convert.ToInt32(id));

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return RedirectToAction("Delete", new { id = id, saveChangesError = true });
        }
    }
}
