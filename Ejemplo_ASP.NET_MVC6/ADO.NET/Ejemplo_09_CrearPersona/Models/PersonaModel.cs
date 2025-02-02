using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ejemplo_09_CrearPersona.Models;

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
