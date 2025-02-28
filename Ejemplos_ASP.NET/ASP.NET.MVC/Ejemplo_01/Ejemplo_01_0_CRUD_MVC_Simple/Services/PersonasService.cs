

using Ejemplo_01_0_CRUD_MVC_Simple.DALs.MSSDALs;
using Ejemplo_01_0_CRUD_MVC_Simple.DAOs.MSSDALs;
using Ejemplo_01_0_CRUD_MVC_Simple.Models;

namespace Ejemplo_01_0_CRUD_MVC_Simple.Services;

public class PersonasService
{
    readonly private PersonasMSSDAL _personasDao;

    public PersonasService(PersonasMSSDAL personasDao)
    {
        _personasDao = personasDao;
    }

    async public Task<List<PersonaModel>> GetAll()
    {
        return await _personasDao.GetAll();
    }

    async public Task<PersonaModel?> GetById(int id)
    {
        return await _personasDao.GetByKey(id);
    }

    async public Task CrearNuevo(PersonaModel objeto)
    {
        await _personasDao.Insert(objeto);
    }

    async public Task Actualizar(PersonaModel objeto)
    {
        await _personasDao.Update(objeto);
    }

    async public Task Eliminar(int id)
    {
        SqlServerTransaction tx = new();
        try
        {
            await tx.BeginTransaction();

            var objeto = await _personasDao.GetByKey(id, tx);
            if (objeto != null)
            {
                await _personasDao.Delete(id, tx);
            }

            await tx.CommitAsync();
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            throw ex;
        }
    }
}
