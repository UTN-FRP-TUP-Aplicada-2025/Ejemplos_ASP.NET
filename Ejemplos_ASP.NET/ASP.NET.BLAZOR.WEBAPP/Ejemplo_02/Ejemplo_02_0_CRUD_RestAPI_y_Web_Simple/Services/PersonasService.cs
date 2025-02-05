using Ejemplo_02_0_CRUD_RestAPI_y_Web_Simple.DALs;
using Ejemplo_02_0_CRUD_RestAPI_y_Web_Simple.DALs.MSSDALs;
using Ejemplo_02_0_CRUD_RestAPI_y_Web_Simple.Models;

namespace Ejemplo_02_0_CRUD_RestAPI_y_Web_Simple.Services;

public class PersonasService
{
    IPersonasDAL _dao = new PersonasMSSDAL();

    public List<PersonaModel> GetAll()
    {
        return _dao.GetAll();
    }

    public PersonaModel? GetById(int id)
    {
        return _dao.GetByKey(id);
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
