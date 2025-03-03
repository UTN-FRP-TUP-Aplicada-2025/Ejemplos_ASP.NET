using Ejemplo_14_Transacciones.DALs.MSSDALs;
using Ejemplo_14_Transacciones.DAOs.MSSDALs;
using Ejemplo_14_Transacciones.Models;

namespace Ejemplo_14_Transacciones.Services;

public class PersonasService
{
    private PersonasMSSDAL _dao = new ();

    async public Task<List<PersonaModel>> GetAll()
    {
        return await _dao.GetAll();
    }

    async public Task<PersonaModel?> GetById(int id)
    {
        return await _dao.GetByKey(id);
    }

    async public Task CrearNuevo(PersonaModel objeto)
    {
        await _dao.Insert(objeto);
    }

    async public Task Actualizar(PersonaModel objeto)
    {
        await _dao.Update(objeto);
    }

    async public Task Eliminar(int id)
    {

        SqlServerTransaction tx = new();
        try
        {
            await tx.BeginTransaction();

            var objeto = await _dao.GetByKey(id,tx;
            if (objeto != null)
            {
                await _dao.Delete(id,tx);
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
