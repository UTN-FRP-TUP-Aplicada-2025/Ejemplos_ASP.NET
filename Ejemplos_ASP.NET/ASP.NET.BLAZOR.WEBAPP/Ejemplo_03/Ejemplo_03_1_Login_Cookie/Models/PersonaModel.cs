using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ejemplo_03_1_Login_Cookie.Models;

public class PersonaModel
{
    [ReadOnly(true)]
    public int Id { get; set; }

    [Required(ErrorMessage="Se requiere ingresar el DNI")]
    [Display(Name = "DNI")]
    public int DNI { get; set; }

    [Required]
    [Display(Name = "Nombre")]
    [StringLength(50, ErrorMessage = "El primer nombre no puede ser mayor a 50 caracteres")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "Se requiere ingresar la Fecha de nacimiento")]
    [Display(Name = "Fecha Nacimiento")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? FechaNacimiento { get; set; }

}
