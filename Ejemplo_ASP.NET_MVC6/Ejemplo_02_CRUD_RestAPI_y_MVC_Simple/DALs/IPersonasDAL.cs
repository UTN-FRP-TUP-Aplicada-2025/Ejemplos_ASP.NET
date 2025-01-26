using Ejemplo_02_CRUD_RestAPI_y_MVC_Simple.Models;

namespace Ejemplo_02_CRUD_RestAPI_y_MVC_Simple.DALs;

public interface IPersonasDAL : IBaseDAL<PersonaModel, int>
{
    List<PersonaModel> GetAll();
    PersonaModel? GetByKey(int id);

    bool Insert(PersonaModel nuevo);
    bool Update(PersonaModel actualizar);

    void Delete(int id);
}
