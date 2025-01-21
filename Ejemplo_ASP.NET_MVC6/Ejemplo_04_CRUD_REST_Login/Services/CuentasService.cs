
using Ejemplo_04_CRUD_REST_Login.DALs;
using Ejemplo_04_CRUD_REST_Login.DALs.MSSDAO;
using Ejemplo_04_CRUD_REST_Login.Models;

namespace Ejemplo_04_CRUD_REST_Login.Services;

public class UsuariosService
{
    IUsuariosDAL _dao = new UsuariosMSSDAL();

    public List<UsuarioModel> GetAll()
    {
        return _dao.GetAll();
    }

    public UsuarioModel? GetById(int id)
    {
        return _dao.GetById(id);
    }

    public void CrearNuevo(UsuarioModel persona)
    {
        _dao.Insert(persona);
    }

    public void Actualizar(UsuarioModel persona)
    {
        _dao.Update(persona);
    }

    public void Eliminar(int id)
    {
        _dao.Delete(id);
    }
}
