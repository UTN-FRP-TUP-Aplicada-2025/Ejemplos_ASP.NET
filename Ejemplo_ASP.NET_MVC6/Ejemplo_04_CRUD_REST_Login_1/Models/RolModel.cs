using System.ComponentModel.DataAnnotations;

namespace Ejemplo_04_CRUD_REST_Login.Models;

public class RolModel
{
    [Key]
    [Required]
    public string Nombre { get; set; }

}
