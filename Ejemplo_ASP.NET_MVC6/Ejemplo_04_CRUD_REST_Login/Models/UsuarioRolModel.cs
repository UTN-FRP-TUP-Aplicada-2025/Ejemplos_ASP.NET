using System.ComponentModel.DataAnnotations;

namespace Ejemplo_04_CRUD_REST_Login.Models;

public class UsuarioRolModel
{
    [Required]
    public string NombreUsuario { get; set; }

    [Required]
    public string NombreRol { get; set; }
}
