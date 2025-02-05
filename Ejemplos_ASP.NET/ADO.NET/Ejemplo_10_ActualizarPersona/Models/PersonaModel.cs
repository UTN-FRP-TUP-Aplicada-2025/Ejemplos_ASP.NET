namespace Ej10_ActualizarPersona.Models;

public class PersonaModel
{
    public int Id { get; set; }

    public int DNI { get; set; }

    public string Nombre { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public override string ToString()
    {
        return $"{Id};{DNI};{Nombre};{FechaNacimiento}";
    }
}
