using System.ComponentModel.DataAnnotations;

namespace Ejemplo_Login_Simple.Models;

public class CuentaModel
{
    [Required]
    public string Name { get; set; }

    [Required]
    [UIHint("password")]
    public string Password { get; set; }

    public string ReturnUrl { get; set; } = "/";
}
