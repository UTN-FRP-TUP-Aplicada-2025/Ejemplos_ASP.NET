using Ejemplo_05_0_Integracion.Models;
using Ejemplo_05_0_Integracion.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ejemplo_05_0_Integracion.RestControllers;

[Route("api/[controller]")]
[ApiController]
public class PersonasController : ControllerBase
{
    private PersonasService _servicio = new PersonasService();

    // GET: api/<PersonasController>
    [HttpGet]
    async public Task<IActionResult> Get()
    {
        return Ok(await _servicio.GetAll());
    }

    // GET api/<PersonasController>/5
    [HttpGet("{id}")]
    async public Task<IActionResult> Get(int id)
    {
        var objeto = await _servicio.GetById(id);
        if (objeto == null)
            return NotFound();

        return Ok(objeto);
    }

    // POST api/<PersonasController>
    [HttpPost]
    async public Task<IActionResult> Post([FromBody] PersonaModel persona)
    {
        if (persona==null && persona.Id<=0)
            return BadRequest();

        await _servicio.CrearNuevo(persona);
      

        if (persona.Id<=0)
            return NotFound();

        return Ok(persona);
    }

    // PUT api/<PersonasController>/5
    [HttpPut("{id}")]
    async public Task<IActionResult> Put(int id, [FromBody] PersonaModel persona)
    {
        if (id == null || id <= 0)
            return BadRequest();

        var objeto = await _servicio.GetById(Convert.ToInt32(id));
        if(objeto == null)
            return NotFound();

        await _servicio.Actualizar(persona);

        return Ok();
    }

    // DELETE api/<PersonasController>/5
    [HttpDelete("{id}")]
    async public Task<IActionResult> Delete(int? id)
    {
        if (id == null || id <= 0)
            return BadRequest();

        var persona = await _servicio.GetById(Convert.ToInt32(id));

        if (persona == null)
            return NotFound();

        return Ok();
    }
}
