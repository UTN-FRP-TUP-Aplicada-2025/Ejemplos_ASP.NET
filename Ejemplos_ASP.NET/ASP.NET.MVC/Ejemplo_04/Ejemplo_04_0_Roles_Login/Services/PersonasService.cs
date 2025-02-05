
using Ejemplo_04_0_Roles_Login.DALs;
using Ejemplo_04_0_Roles_Login.DALs.MSSDAO;
using Ejemplo_04_0_Roles_Login.Models;

namespace Ejemplo_04_0_Roles_Login.Services;

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
