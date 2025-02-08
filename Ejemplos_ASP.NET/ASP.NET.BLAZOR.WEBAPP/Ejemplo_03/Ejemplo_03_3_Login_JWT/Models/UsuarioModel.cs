using System.ComponentModel.DataAnnotations;

namespace Ejemplo_03_0_Login_Cookie.Models;

public class UsuarioModel
{
    [Key]
    [Required]
    [StringLength(50, ErrorMessage = "El primer nombre no puede ser mayor a 20 caracteres")]
    public string Nombre { get; set; }

    [Required]
    [UIHint("password")]
    [StringLength(200, ErrorMessage = "El primer nombre no puede ser mayor a 200 caracteres")]
    public string Clave { get; set; }

    public string ReturnUrl { get; set; } = "/";

}
