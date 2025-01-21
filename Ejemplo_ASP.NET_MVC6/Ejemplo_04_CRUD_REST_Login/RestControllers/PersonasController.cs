using Ejemplo_04_CRUD_REST_Login.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ejemplo_04_CRUD_REST_Login.RestControllers;

[Route("api/[controller]")]
[ApiController]
public class PersonasController : ControllerBase
{
    private PersonasService servicio = new PersonasService();

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(servicio.GetAll());
    }
}
