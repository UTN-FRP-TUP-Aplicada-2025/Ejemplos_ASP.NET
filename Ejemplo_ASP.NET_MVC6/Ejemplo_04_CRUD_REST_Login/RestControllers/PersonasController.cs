using Microsoft.AspNetCore.Mvc;

namespace Ejemplo_04_CRUD_REST_Login.RestControllers;

[Route("api/[controller]")]
[ApiController]
public class PersonasController : ControllerBase
{
    // GET: api/<PersonasController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    
}
