using System.ComponentModel.DataAnnotations;

namespace Ejemplo_03_CRUD_Simple_Login.Models
{
    public class RolModel
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}
