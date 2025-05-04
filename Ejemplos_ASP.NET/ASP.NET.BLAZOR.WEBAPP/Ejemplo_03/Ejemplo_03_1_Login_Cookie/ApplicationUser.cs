using Microsoft.AspNetCore.Identity;

namespace Ejemplo_03_1_Login_Cookie
{
    public class ApplicationUser : IdentityUser
    {
        // Puedes agregar propiedades personalizadas aquí si necesitas almacenar
        // información adicional sobre tus usuarios que no está incluida
        // en IdentityUser. Por ejemplo:
        public string? NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        // ... otras propiedades personalizadas
    }
}
