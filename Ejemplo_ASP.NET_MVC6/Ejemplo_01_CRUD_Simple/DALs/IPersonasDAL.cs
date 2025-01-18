using Ejemplo_CRUD_Simple.Models;

namespace Ejemplo_CRUD_Simple.DALs;

public interface IPersonasDAL
{
    List<PersonaModel> GetAll();
    PersonaModel? GetById(int id);

    bool Insert(PersonaModel nuevo);
    bool Update(PersonaModel actualizar);

    void Delete(int id);
}
