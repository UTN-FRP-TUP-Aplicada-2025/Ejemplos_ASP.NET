using Ejemplo_10_form_dinamico.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Ejemplo_10_form_dinamico.Controllers;

public class DynamicFormController : Controller
{
    public IActionResult Index()
    {
        var jsonData = @"
        {
            ""fields"": [
                { ""type"": ""text"", ""label"": ""Nombre"", ""placeholder"": ""Ingresa tu nombre"", ""required"": true },
                { ""type"": ""email"", ""label"": ""Correo Electrónico"", ""placeholder"": ""Ingresa tu correo"", ""required"": true },
                { ""type"": ""password"", ""label"": ""Contraseña"", ""placeholder"": ""Ingresa tu contraseña"", ""required"": true },
                { ""type"": ""dropdown"", ""label"": ""Género"", ""options"": [""Masculino"", ""Femenino"", ""Otro""], ""required"": true }
            ]
        }";

        var fields = JsonSerializer.Deserialize<Dictionary<string, List<FormFieldModel>>>(jsonData);

        return View(fields["fields"]);
    }

    [HttpPost]
    public IActionResult Submit(Dictionary<string, string> formData)
    {
        ViewBag.FormData = formData;
        return View("Result");
    }
}
