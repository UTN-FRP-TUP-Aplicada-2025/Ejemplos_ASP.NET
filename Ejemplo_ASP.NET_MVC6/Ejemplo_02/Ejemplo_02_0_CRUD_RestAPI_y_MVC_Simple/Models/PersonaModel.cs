using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ejemplo_02_0_CRUD_RestAPI_y_MVC_Simple.Models;

public class PersonaModel
{
    [Required]
    [DisplayName("Id")]
    public int Id { get; set; }

    [Required]
    [DisplayName("DNI")]
    public int DNI { get; set; }

    [Required]
    [DisplayName("Nombre")]
    public string Nombre { get; set; }

    [DisplayName("Fecha de Nacimiento")]
    public DateTime? FechaNacimiento { get; set; }
}
