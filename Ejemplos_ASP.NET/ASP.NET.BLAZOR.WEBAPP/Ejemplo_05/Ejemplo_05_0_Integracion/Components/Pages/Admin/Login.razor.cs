using Ejemplo_05_0_Integracion.Models;
using Ejemplo_05_0_Integracion.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using System.Reflection;
using System.Security.Claims;

namespace Ejemplo_05_0_Integracion.Components.Pages.Admin;

public partial class Login
{
    // [CascadingParameter]
    // public HttpContext? httpContext { get; set; }

    [SupplyParameterFromForm]
    private UsuarioModel Model { get; set; } = new();

    private UsuariosService _usuarioService = new UsuariosService();

    
    //necesario para el acceso al contexto
    [Inject] IHttpContextAccessor HttpContextAccessor { get; set; }

    private string? errorMessages;

    async private Task onValidarLogin()
    {
        if (await _usuarioService.VerificarLogin(Model) == false)
        {
            errorMessages = " Usuario o Contraseña no válidos!";
            return;
        }

        var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, Model.Nombre),
        new Claim("CUIT", "23244324") // claim personalizada
    };

        var identity = new ClaimsIdentity(claims, "Cookies");
        var principal = new ClaimsPrincipal(identity);

        // Acceder a HttpContext a través de IHttpContextAccessor
        var httpContext = HttpContextAccessor.HttpContext;
        if (httpContext != null)
        {
            await httpContext.SignInAsync("Cookies", principal);
            //Navigation.NavigateTo("/admin/personas", forceLoad: true);

            var returnUrl = httpContext.Request.Query["returnurl"];

            // if (string.IsNullOrEmpty(returnUrl))
            // {
            returnUrl = "/admin/personas";
            // }

            //  var returnUrl = Navigation.Uri.Contains("returnurl=")
            // ? Navigation.Uri.Split("returnurl=")[1]
            // : "/admin/personas";

            Navigation.NavigateTo(returnUrl, forceLoad: true);
        }
        else
        {
            errorMessages = "No se pudo iniciar sesión debido a un error interno.";
        }

    }
}
