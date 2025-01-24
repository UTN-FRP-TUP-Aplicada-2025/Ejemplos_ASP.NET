using Ejemplo_04_CRUD_REST_Login.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ejemplo_04_CRUD_REST_Login.RestControllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class PersonasController : ControllerBase
{
    private PersonasService _servicio = new PersonasService();

    /// <summary>
    /// Obtiene todas las personas registradas.
    /// </summary>
    /// <returns>Una lista de personas.</returns>
    /// <response code="200">Devuelve la lista de personas.</response>
    /// <response code="500">Si ocurre un error interno.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Models.PersonaModel>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Get()
    {
        try
        {
            var personas = _servicio.GetAll();
            return Ok(personas);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un error interno.", error = ex.Message });
        }
    }
}
