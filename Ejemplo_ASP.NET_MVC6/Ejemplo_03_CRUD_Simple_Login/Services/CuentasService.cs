using Ejemplo_CRUD_Simple_Login.Models;
using EjemploASP.NET_MVC.DALs;
using EjemploASP.NET_MVC.DALs.MSSDAO;

namespace Ejemplo_CRUD_Simple_Login.NET_MVC.Services;

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
