using Ejemplo_13_Personas.Models;

namespace Ejemplo_13_Personas.DALs;

public interface IPersonasDAL : IBaseDAL<PersonaModel, int>
{
    List<PersonaModel> GetAll();
    PersonaModel? GetByKey(int id);

    bool Insert(PersonaModel nuevo);
    bool Update(PersonaModel actualizar);

    void Delete(int id);
}
