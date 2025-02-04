using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ejemplo_02_0_CRUD_RestAPI_Simple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaController : ControllerBase
    {
        
        [HttpGet("GetLista1")]
        public IEnumerable<string> GetLista1()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("Getlista2")]
        public IEnumerable<string> GeLista2()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("GetItem/{Id}")]
        public string GeLista2(int id)
        {
            return new string[] { "value1", "value2" }[id];
        }

    }
}
