using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ejemplo_01_Personas.Models;

[Table("Personas")]
public class PersonaModel
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }

    [Required]
    [Column("Dni")]
    public int DNI { get; set; }

    [Required]
    [StringLength(100)]
    [Column("Nombre")]
    public string Nombre { get; set; }


    [Column("Fecha_Nacimiento")]
    public DateTime? FechaNacimiento { get; set; }
}
