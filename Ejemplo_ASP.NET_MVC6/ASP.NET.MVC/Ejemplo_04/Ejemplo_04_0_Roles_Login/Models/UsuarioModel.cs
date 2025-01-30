using System.ComponentModel.DataAnnotations;

namespace Ejemplo_04_0_Roles_Login.Models;

public class UsuarioModel
{
    [Key]
    [Required]
    public string Nombre { get; set; }

    [Required]
    [UIHint("password")]
    public string Clave { get; set; }

    public string ReturnUrl { get; set; } = "/";

}
