namespace Ejemplo_03_CRUD_Simple_Login.DALs;

public interface IBaseDAL<T>
{
    List<T> GetAll();
    T? GetById(int id);

    bool Insert(T nuevo);
    bool Update(T actualizar);

    void Delete(int id);
}
