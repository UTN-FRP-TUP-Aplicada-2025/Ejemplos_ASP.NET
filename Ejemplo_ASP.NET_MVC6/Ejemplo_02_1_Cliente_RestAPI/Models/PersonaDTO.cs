
using System.Text.Json.Serialization;

namespace Ejemplo_02_1_Cliente_RestAPI.Models;

public class PersonaDTO
{
    [JsonPropertyName("dni")]
    public int DNI { get; set; }
    
    [JsonPropertyName("nombre")]
    public string Nombre { get; set; }
}
