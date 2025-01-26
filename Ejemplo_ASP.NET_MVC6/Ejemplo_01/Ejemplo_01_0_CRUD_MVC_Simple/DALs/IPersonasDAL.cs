using Ejemplo_01_CRUD_MVC_Simple.Models;

namespace Ejemplo_01_CRUD_MVC_Simple.DALs;

public interface IPersonasDAL : IBaseDAL<PersonaModel, int>
{
    List<PersonaModel> GetAll();
    PersonaModel? GetByKey(int id);

    bool Insert(PersonaModel nuevo);
    bool Update(PersonaModel actualizar);

    void Delete(int id);
}
