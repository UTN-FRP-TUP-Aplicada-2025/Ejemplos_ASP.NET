using System.ComponentModel.DataAnnotations;

namespace Ejemplo_03_CRUD_Simple_Login.Models;

public class CuentaModel
{
    [Key]
    public int? Id { get; set; }
        
    public string? UUID { get; set; }

    [Required]
    public string? Nombre { get; set; }

    [Required]
    [UIHint("password")]
    public string? Clave { get; set; }

    public string ReturnUrl { get; set; } = "/";
}
