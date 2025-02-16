using Ejemplo_05_0_Integracion.Utils;
using Microsoft.AspNetCore.Components;

namespace Ejemplo_05_0_Integracion.Components.Pages.Admin;

public partial class Datos:ComponentBase
{
    [Inject] UsuarioService UsuarioService { get; set; }
    private string? cuit;

    protected override async Task OnInitializedAsync()
    {
        cuit = UsuarioService.ObtenerCUIT();
    }

    string valor = "";

    [Inject] private IHttpContextAccessor _httpContextAccessor { get; set; }

    protected async Task OnSetCookieClick()
    {
        var context = _httpContextAccessor.HttpContext;

        if (context != null)
        {
            context.Response.Cookies.Append("Mi_Cookie_De_Estado", $"{"324324"}", new CookieOptions
            {
                Expires = DateTime.UtcNow.AddMinutes(30),
                HttpOnly = false,
                Secure = true,
                SameSite = SameSiteMode.Strict
            });
        }
    }

    protected async Task OnGetCookieClick()
    {
        (_, valor) = GetCookie();
    }

    public (string? Nombre, string? Email) GetCookie()
    {
        var context = _httpContextAccessor.HttpContext;
        if (context != null && context.Request.Cookies.TryGetValue("Mi_Cookie_De_Estado", out var valor))
        {
            var datos = valor.Split('|');
            return ("nada", datos.Length > 1 ? datos[1] : null);
        }
        return (null, null);
    }
}
