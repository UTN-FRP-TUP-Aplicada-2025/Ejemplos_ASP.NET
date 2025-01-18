using Ejemplo_CRUD_Simple_Login.Models;
using EjemploASP.NET_MVC.DALs;
using EjemploASP.NET_MVC.DALs.MSSDAO;

namespace Ejemplo_CRUD_Simple_Login.NET_MVC.Services;

public class PersonasService
{
    IPersonasDAL _dao = new PersonasMSSDAL();

    public List<PersonaModel> GetAll()
    {
        return _dao.GetAll();
    }

    public PersonaModel? GetById(int id)
    {
        return _dao.GetById(id);
    }

    public void CrearNuevo(PersonaModel persona)
    {
        _dao.Insert(persona);
    }

    public void Actualizar(PersonaModel persona)
    {
        _dao.Update(persona);
    }

    public void Eliminar(int id)
    {
        _dao.Delete(id);
    }
}
