using System.ComponentModel.DataAnnotations;

namespace Ejemplo_04_CRUD_REST_Login.Models;

public class UsuarioRolModel
{
    [Required]
    public int? IdUsuario { get; set; }

    [Required]
    public int? IdRol { get; set; }
}
