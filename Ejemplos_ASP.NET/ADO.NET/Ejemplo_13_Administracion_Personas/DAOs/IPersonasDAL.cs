using Ejemplo_13_Personas.Models;

namespace Ejemplo_13_Personas.DALs;

public interface IPersonasDAL : IBaseDAL<PersonaModel, int>
{
    Task<List<PersonaModel>> GetAll();
    Task<PersonaModel?> GetByKey(int id);

    Task<bool> Insert(PersonaModel nuevo);
    Task<bool> Update(PersonaModel actualizar);

    Task Delete(int id);
}
