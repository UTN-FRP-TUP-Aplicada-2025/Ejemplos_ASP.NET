namespace Ejemplo_15_personas_datoslib.DALs;

public interface IBaseDAL<T, K, M>
{
    Task<List<T>> GetAll(ITransaction<M>? transaccion = null);
    Task<T?> GetByKey(K id, ITransaction<M>? transaccion = null);
    Task<bool> Insert(T nuevo, ITransaction<M>? transaccion = null);
    Task<bool> Update(T actualizar, ITransaction<M>? transaccion = null);
    Task<bool> Delete(K id, ITransaction<M>? transaccion = null);
}
