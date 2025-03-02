using Ejemplo_15_personas_datoslib.Models;
using Ejemplo_15_personas_datoslib.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ejemplo_05_Areas.RestControllers;

[Route("api/[controller]")]
[ApiController]
public class PersonasController : ControllerBase
{
    private readonly ILogger<PersonasController> _logger;

    private readonly PersonasService _personasService;

    public PersonasController(ILogger<PersonasController> logger, PersonasService personasService)
    {
        _logger = logger;
        _personasService = personasService;
    }

    // GET: api/<PersonasController>
    [HttpGet]
    async public Task<IActionResult> Get()
    {
        return Ok(await _personasService.GetAll());
    }

    // GET api/<PersonasController>/5
    [HttpGet("{id}")]
    async public Task<IActionResult> Get(int id)
    {
        var persona = await _personasService.GetById(id);
        return Ok(persona);
    }

    // POST api/<PersonasController>
    [HttpPost]
    async public Task<IActionResult> Post([FromBody] PersonaModel persona)
    {
        await _personasService.CrearNuevo(persona);
        return RedirectToAction(nameof(Index));
    }

    // PUT api/<PersonasController>/5
    [HttpPut("{id}")]
    async public Task Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<PersonasController>/5
    [HttpDelete("{id}")]
    async public Task<IActionResult> Delete(int? id)
    {
        if (id == null || id <= 0)
            return BadRequest();

        var persona =await _personasService.GetById(Convert.ToInt32(id));

        if (persona == null)
            return NotFound();

        return Ok();
    }
}
