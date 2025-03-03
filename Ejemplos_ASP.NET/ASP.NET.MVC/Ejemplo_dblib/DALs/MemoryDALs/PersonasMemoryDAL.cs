using Ejemplo_15_personas_datoslib.Models;

namespace Ejemplo_15_personas_datoslib.DALs.MemoryDALs;

public class PersonasMemoryDAL : IBaseDAL<PersonaModel, int, object>
{
    static int GEN=0;
    static public List<PersonaModel> personas = new List<PersonaModel>
    {
        new PersonaModel(){ Id=1,DNI=2343243, Nombre="Esteban"},
        new PersonaModel(){ Id=2,DNI=3343243, Nombre="Betiana"}
    };

    async public Task<List<PersonaModel>> GetAll(ITransaction<object>? transaccion = null)
    {
        return personas;
    }

    async public Task<PersonaModel?> GetByKey(int id, ITransaction<object>? transaccion = null)
    {
        
        return personas.Where(p=>p.Id==id).FirstOrDefault();
    }

    async public Task<bool> Insert(PersonaModel nuevo, ITransaction<object>? transaccion = null)
    {
        PersonaModel? model = await GetByKey(nuevo.Id);

        if (model == null)
        {
            personas.Add(model);
            return true;
        }
        return false;
    }

    async public Task<bool> Update(PersonaModel actualizar, ITransaction<object>? transaccion = null)
    {
        PersonaModel? model = await GetByKey(actualizar.Id);

        if (model != null)
        {
            personas.Add(model);
            return true;
        }
        return false;
    }

    async public Task<bool> Delete(int id, ITransaction<object>? transaccion = null)
    {
        PersonaModel? model = await GetByKey(id);

        if (model != null)
        {
            personas.Remove(model);
            return true;
        }
        return false;
    } 
}
