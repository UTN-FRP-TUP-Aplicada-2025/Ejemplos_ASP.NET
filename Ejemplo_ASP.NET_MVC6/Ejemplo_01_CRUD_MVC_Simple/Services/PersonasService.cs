using Ejemplo_01_CRUD_MVC_Simple.DALs;
using Ejemplo_01_CRUD_MVC_Simple.DALs.MSSDALs;
using Ejemplo_01_CRUD_MVC_Simple.Models;

namespace Ejemplo_01_CRUD_MVC_Simple.Services;

public class PersonasService
{
    //IPersonasDAO _dao = new PersonasMemoryDAO();
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
