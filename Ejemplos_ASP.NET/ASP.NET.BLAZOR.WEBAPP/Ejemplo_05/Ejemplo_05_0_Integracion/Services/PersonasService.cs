
using Ejemplo_05_0_Integracion.DALs;
using Ejemplo_05_0_Integracion.DALs.MSSDALs;
using Ejemplo_05_0_Integracion.Models;

namespace Ejemplo_05_0_Integracion.Services;

public class PersonasService
{
    PersonasMSSDAL _personasDao = new PersonasMSSDAL();

    async public Task<List<PersonaModel>> GetAll()
    {
        return await _personasDao.GetAll();
    }

    async public Task<PersonaModel?> GetById(int id)
    {
        return await _personasDao.GetByKey(id);
    }

    async public Task<bool> CrearNuevo(PersonaModel persona)
    {
        return await _personasDao.Insert(persona);
    }

    async public Task<bool> Actualizar(PersonaModel persona)
    {
        return await _personasDao.Update(persona);
    }

    async public Task<bool> Eliminar(int id)
    {
        return await _personasDao.Delete(id);
    }
}
