using Ejemplo_02_0_CRUD_RestAPI_Simple.Models;

namespace Ejemplo_02_0_CRUD_RestAPI_Simple.DALs;

public interface IPersonasDAL : IBaseDAL<PersonaModel, int>
{
    List<PersonaModel> GetAll();
    PersonaModel? GetByKey(int id);

    bool Insert(PersonaModel nuevo);
    bool Update(PersonaModel actualizar);

    void Delete(int id);
}
