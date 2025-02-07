using Ejemplo_05_0_Integracion.Models;
using Ejemplo_05_0_Integracion.Services;

using Microsoft.AspNetCore.Mvc;

namespace Ejemplo_05_0_Integracion.RestControllers;

[Route("api/[controller]")]
[ApiController]
public class PersonasController : ControllerBase
{
    private PersonasService _servicio = new PersonasService();

    // GET: api/<PersonasController>
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_servicio.GetAll());
    }

    // GET api/<PersonasController>/5
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var persona = _servicio.GetById(id);
        return Ok(persona);
    }

    // POST api/<PersonasController>
    [HttpPost]
    public IActionResult Post([FromBody] PersonaModel persona)
    {
        _servicio.CrearNuevo(persona);
        return RedirectToAction(nameof(Index));
    }

    // PUT api/<PersonasController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<PersonasController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int? id)
    {
        if (id == null || id <= 0)
            return BadRequest();

        var persona = _servicio.GetById(Convert.ToInt32(id));

        if (persona == null)
            return NotFound();

        return Ok();
    }
}
