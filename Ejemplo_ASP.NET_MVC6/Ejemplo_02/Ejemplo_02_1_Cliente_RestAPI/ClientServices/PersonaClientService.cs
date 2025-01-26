
using Ejemplo_02_1_Cliente_RestAPI.Models;
using System.Text.Json;

namespace Ejemplo_02_1_Cliente_RestAPI.ClientServices;

internal class PersonaClientService
{
   
    async public Task<List<PersonaDTO>> GetAll()
    {
        /* alternativa
        var personas = new List<PersonaDTO>();

        string url = "https://localhost:7154/api/Personas";

        var cliente = new HttpClient();

        var response = await cliente.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync();

            personas = JsonSerializer.Deserialize<List<PersonaDTO>>(json);
        }

        return personas;
        */

        var personas = new List<PersonaDTO>();

        string url = "https://localhost:7154/api/Personas";

        using var client = new HttpClient();

        var consulta = new HttpRequestMessage(HttpMethod.Get, url);

        var respuesta = await client.SendAsync(consulta);

        if (respuesta.IsSuccessStatusCode)
        {
            var json = await respuesta.Content.ReadAsStringAsync();
            personas = JsonSerializer.Deserialize<List<PersonaDTO>>(json);
        }
        return personas;
    }
}
