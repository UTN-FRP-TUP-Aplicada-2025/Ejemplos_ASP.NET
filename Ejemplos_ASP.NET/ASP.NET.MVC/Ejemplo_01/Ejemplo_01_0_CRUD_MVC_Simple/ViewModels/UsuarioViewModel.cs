using Ejemplo_15_personas_datoslib.Models;

namespace Ejemplo_01_CRUD_MVC_Simple.ViewModels;

public class UsuarioViewModel
{
    public UsuarioModel Usuario { get; set; } = new UsuarioModel(); 
    public List<UsuarioModel> Usuarios { get; set; } = new List<UsuarioModel>();
}
