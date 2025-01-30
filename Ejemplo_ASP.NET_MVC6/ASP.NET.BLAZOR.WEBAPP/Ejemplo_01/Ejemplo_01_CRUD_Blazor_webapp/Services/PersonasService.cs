using Ejemplo_01_CRUD_Blazor_webapp.DALs;
using Ejemplo_01_CRUD_Blazor_webapp.DALs.MSSDALs;
using Ejemplo_01_CRUD_Blazor_webapp.Models;

namespace Ejemplo_01_CRUD_Blazor_webapp.Services;

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
