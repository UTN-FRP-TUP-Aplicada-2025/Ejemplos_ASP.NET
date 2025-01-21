using System.ComponentModel.DataAnnotations;

namespace Ejemplo_04_CRUD_REST_Login.Models;

public class RolModel
{
    [Key]
    public int? Id { get; set; }

    [Required]
    public string Nombre { get; set; }

}
