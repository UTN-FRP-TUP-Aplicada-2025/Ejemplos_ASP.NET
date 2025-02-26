
using Ejemplo_02_1_Cliente_RestAPI.Models;
using System.Net.Http.Json;
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

        //string url = "https://localhost:7154/api/Personas/";
        string url = "https://ejemplosaspnet.somee.com/api/Personas";

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

    async public Task<PersonaDTO> Insert(PersonaDTO persona)
    {
        string url = "https://ejemplosaspnet.somee.com/api/Personas";

        using HttpClient client = new HttpClient();
        var response=await client.PostAsJsonAsync<PersonaDTO>(url,persona);
        
        PersonaDTO resultado = null;
        if (response.IsSuccessStatusCode == true)
        {
            resultado = await response.Content.ReadFromJsonAsync<PersonaDTO>();
        }

        return resultado;
    }

    async public Task<PersonaDTO> Insert2(PersonaDTO persona)
    {
        string url = "https://ejemplosaspnet.somee.com/api/Personas";

        using HttpClient client = new HttpClient();
          
        //crea la consulta post
        var request=new HttpRequestMessage(HttpMethod.Post, url);
        request.Content = JsonContent.Create(persona);

        //envia y recibe el response
        HttpResponseMessage response=await client.SendAsync(request);

        PersonaDTO resultado = null;
        if (response.IsSuccessStatusCode == true)
        {
            resultado = await response.Content.ReadFromJsonAsync<PersonaDTO>();
        }

        return resultado;
    }

    async public Task<PersonaDTO> GetById(int id)
    {
        string url = $"https://ejemplosaspnet.somee.com/api/Personas/{id}";

        using HttpClient client = new HttpClient();
        PersonaDTO respuestaDto = await client.GetFromJsonAsync<PersonaDTO>(url);

        return respuestaDto;
    }

    async public Task<PersonaDTO> Actualizar(PersonaDTO persona)
    {
        string url = "https://ejemplosaspnet.somee.com/api/Personas";

        using HttpClient client = new HttpClient();
        var response = await client.PutAsJsonAsync<PersonaDTO>(url, persona);

        PersonaDTO resultado = null;
        if (response.IsSuccessStatusCode == true)
        {
            resultado = await response.Content.ReadFromJsonAsync<PersonaDTO>();
        }

        return resultado;
    }
}