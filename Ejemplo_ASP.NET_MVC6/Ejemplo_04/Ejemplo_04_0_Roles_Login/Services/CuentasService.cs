
using Ejemplo_04_0_Roles_Login.DALs;
using Ejemplo_04_0_Roles_Login.DALs.MSSDAO;
using Ejemplo_04_0_Roles_Login.Models;


namespace Ejemplo_04_0_Roles_Login.Services;

public class UsuariosService
{
    IUsuariosDAL _dao = new UsuariosMSSDAL();

    public bool VerificarLogin(UsuarioModel usuarioVerificar)
    { 
        var usuario = _dao.GetByKey(usuarioVerificar.Nombre);
        return usuario != null && usuarioVerificar.Clave == usuario.Clave;
    }

    public List<UsuarioModel> GetAll()
    {
        return _dao.GetAll();
    }

    public UsuarioModel? GetByNombre(string nombre)
    {
        return _dao.GetByKey(nombre);
    }

    public void CrearNuevo(UsuarioModel persona)
    {
        _dao.Insert(persona);
    }

    public void Actualizar(UsuarioModel persona)
    {
        _dao.Update(persona);
    }

    public void Eliminar(string nombre)
    {
        _dao.Delete(nombre);
    }
}
