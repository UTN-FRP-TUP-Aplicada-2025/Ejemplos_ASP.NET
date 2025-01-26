using System.ComponentModel.DataAnnotations;

namespace Ejemplo_04_0_Roles_Login.Models;

public class RolModel
{
    [Key]
    [Required]
    public string Nombre { get; set; }

}
