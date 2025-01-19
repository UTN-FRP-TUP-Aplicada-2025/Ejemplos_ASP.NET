using System.ComponentModel.DataAnnotations;

namespace Ejemplo_03_CRUD_Simple_Login.Models
{
    public class CuentaRolModel
    {
        [Required]
        public int? IdCuenta { get; set; }

        [Required]
        public int? IdRol { get; set; }
    }
}
