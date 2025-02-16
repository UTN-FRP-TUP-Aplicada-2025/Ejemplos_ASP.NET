using Microsoft.Extensions.Configuration;

public class MiServicio : IMiServicio
{
    private readonly IConfiguration _configuracion;

    public MiServicio(IConfiguration configuracion)
    {
        _configuracion = configuracion;
    }

    public void MostrarConexion()
    {
        var cadenaConexion = _configuracion.GetConnectionString("CadenaConexion");
        Console.WriteLine($"Cadena de conexión: {cadenaConexion}");
    }
}