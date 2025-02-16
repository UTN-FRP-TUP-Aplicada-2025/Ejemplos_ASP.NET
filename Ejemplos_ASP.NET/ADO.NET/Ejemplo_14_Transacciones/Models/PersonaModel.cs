using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ejemplo_05_0_Integracion.Models;

public class PersonaModel
{
    [JsonPropertyName("id")]
    [ReadOnly(true)]
    public int Id { get; set; }

    [JsonPropertyName("dni")]
    [Required(ErrorMessage="Se requiere ingresar el DNI")]
    [Display(Name = "DNI")]
    public int DNI { get; set; }

    [JsonPropertyName("nombre")]
    [Required]
    [Display(Name = "Nombre")]
    [StringLength(50, ErrorMessage = "El primer nombre no puede ser mayor a 50 caracteres")]
    public string Nombre { get; set; }

    [JsonPropertyName("fechaNacimiento")]
    [Required(ErrorMessage = "Se requiere ingresar la Fecha de nacimiento")]
    [Display(Name = "Fecha Nacimiento")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? FechaNacimiento { get; set; }

}
