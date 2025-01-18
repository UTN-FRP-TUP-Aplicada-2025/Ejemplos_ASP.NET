namespace EjemploASP.NET_MVC.DALs;

public interface IBaseDAL<T>
{
    List<T> GetAll();
    T? GetById(int id);

    bool Insert(T nuevo);
    bool Update(T actualizar);

    void Delete(int id);
}
