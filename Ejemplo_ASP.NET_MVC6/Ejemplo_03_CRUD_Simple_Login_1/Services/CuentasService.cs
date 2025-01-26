
using Ejemplo_03_CRUD_Simple_Login.DALs;
using Ejemplo_03_CRUD_Simple_Login.DALs.MSSDAO;
using Ejemplo_03_CRUD_Simple_Login.Models;

namespace Ejemplo_03_CRUD_Simple_Login.Services;

public class CuentasService
{
    ICuentasDAL _dao = new CuentasMSSDAL();

    public List<CuentaModel> GetAll()
    {
        return _dao.GetAll();
    }

    public CuentaModel? GetById(int id)
    {
        return _dao.GetById(id);
    }

    public void CrearNuevo(CuentaModel persona)
    {
        _dao.Insert(persona);
    }

    public void Actualizar(CuentaModel persona)
    {
        _dao.Update(persona);
    }

    public void Eliminar(int id)
    {
        _dao.Delete(id);
    }
}
