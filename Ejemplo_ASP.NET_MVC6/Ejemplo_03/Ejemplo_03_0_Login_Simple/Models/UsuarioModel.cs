using System.ComponentModel.DataAnnotations;

namespace Ejemplo_03_0_Login_Simple.Models;

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
