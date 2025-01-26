using System.ComponentModel.DataAnnotations;

namespace Ejemplo_01_0_CRUD_MVC_Simple.Models;

public class PersonaModel
{
    [Required]
    public int Id { get; set; }

    [Required]
    public int DNI { get; set; }

    [Required]
    public string Nombre { get; set; }
    public DateTime? FechaNacimiento { get; set; }
}
