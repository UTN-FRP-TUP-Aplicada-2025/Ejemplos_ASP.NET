using Ejemplo_14_Transacciones.DAOs;

namespace Ejemplo_14_Transacciones.DALs;

public interface IBaseDAL<T, K, M>
{
    Task<List<T>> GetAll(ITransaction<M>? transaccion = null);
    Task<T?> GetByKey(K id, ITransaction<M>? transaccion = null);
    Task<bool> Insert(T nuevo, ITransaction<M>? transaccion = null);
    Task<bool> Update(T actualizar, ITransaction<M>? transaccion = null);
    Task<bool> Delete(K id, ITransaction<M>? transaccion = null);
}
