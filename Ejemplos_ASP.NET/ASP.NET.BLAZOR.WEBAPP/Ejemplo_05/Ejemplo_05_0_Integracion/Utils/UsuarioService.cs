namespace Ejemplo_05_0_Integracion.Utils;

public class UsuarioService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UsuarioService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? ObtenerCUIT()
    {
        var cuit = _httpContextAccessor.HttpContext?.User.FindFirst("CUIT")?.Value;
        return cuit;
    }
}