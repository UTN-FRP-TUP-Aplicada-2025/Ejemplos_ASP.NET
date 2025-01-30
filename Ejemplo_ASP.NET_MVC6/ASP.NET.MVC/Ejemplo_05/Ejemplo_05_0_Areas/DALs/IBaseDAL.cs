namespace Ejemplo_05_Areas.DALs;

public interface IBaseDAL<T, K>
{
    List<T> GetAll();
    T? GetByKey(K key);

    bool Insert(T nuevo);
    bool Update(T actualizar);

    void Delete(K id);
}
