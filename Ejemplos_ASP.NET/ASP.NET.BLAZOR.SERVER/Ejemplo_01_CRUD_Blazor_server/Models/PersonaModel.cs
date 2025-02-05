using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ejemplo_01_CRUD_Blazor_server.Models;

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
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? FechaNacimiento { get; set; }
}
