namespace Ejemplo_03_0_Login_Simple.DALs;

public interface IBaseDAL<T, K>
{
    List<T> GetAll();
    T? GetByKey(K key);

    bool Insert(T nuevo);
    bool Update(T actualizar);

    void Delete(K id);
}
