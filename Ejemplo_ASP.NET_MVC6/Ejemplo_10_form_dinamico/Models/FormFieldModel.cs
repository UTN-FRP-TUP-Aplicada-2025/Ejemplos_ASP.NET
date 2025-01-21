using System.Text.Json.Serialization;

namespace Ejemplo_10_form_dinamico.Models;

public class FormFieldModel
{
    [JsonPropertyName("type")]
    public string Type { get; set; } // text, email, password, dropdown

    [JsonPropertyName("label")]
    public string Label { get; set; }

    [JsonPropertyName("placeholder")]
    public string Placeholder { get; set; }

    [JsonPropertyName("required")]
    public bool Required { get; set; }

    [JsonPropertyName("options")]
    public List<string>? Options { get; set; } // Solo para dropdowns
}