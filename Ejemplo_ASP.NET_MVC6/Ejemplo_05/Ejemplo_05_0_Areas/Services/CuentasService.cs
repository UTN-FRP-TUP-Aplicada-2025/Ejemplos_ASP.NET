
using Ejemplo_05_Areas.DALs;
using Ejemplo_05_Areas.DALs.MSSDALs;
using Ejemplo_05_Areas.Models;

namespace Ejemplo_05_Areas.Services;

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
