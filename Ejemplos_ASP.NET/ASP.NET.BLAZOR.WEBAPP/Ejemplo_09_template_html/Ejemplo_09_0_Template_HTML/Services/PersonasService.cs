
using Ejemplo_09_0_Template_HTML.DALs;
using Ejemplo_09_0_Template_HTML.DALs.MSSDALs;
using Ejemplo_09_0_Template_HTML.Models;

namespace Ejemplo_09_0_Template_HTML.Services;

public class PersonasService
{
    IPersonasDAL _dao = new PersonasMSSDAL();

    async public Task<List<PersonaModel>> GetAll()
    {
        return await _dao.GetAll();
    }

    async public Task<PersonaModel?> GetById(int id)
    {
        return await _dao.GetByKey(id);
    }

    async public Task<bool> CrearNuevo(PersonaModel persona)
    {
        return await _dao.Insert(persona);
    }

    async public Task<bool> Actualizar(PersonaModel persona)
    {
        return await _dao.Update(persona);
    }

    async public Task<bool> Eliminar(int id)
    {
        return await _dao.Delete(id);
    }
}
