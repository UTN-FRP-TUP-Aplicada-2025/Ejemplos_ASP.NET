using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ejemplo_02_0_CRUD_RestAPI_y_Web_Simple.RestControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedirigirController : ControllerBase
    {
        
        [HttpGet("Redirigir")]
        async public Task<IActionResult> RedirigirAsync(string url)
        {
            return Redirect(url);
        }
    }
}
