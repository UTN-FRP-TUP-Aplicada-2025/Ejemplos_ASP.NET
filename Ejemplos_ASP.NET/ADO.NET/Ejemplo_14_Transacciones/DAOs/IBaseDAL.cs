using Ejemplo_14_Transacciones.DAOs;
using System.Threading.Tasks;

namespace Ejemplo_13_Personas.DALs;

public interface IBaseDAL<T, K, M>
{
    Task<List<T>> GetAll(ITransaction<M>? transaccion = null);
    Task<T?> GetByKey(int id, ITransaction<M>? transaccion = null);
    Task<bool> Insert(T nuevo, ITransaction<M>? transaccion = null);
    Task<bool> Update(T actualizar, ITransaction<M>? transaccion = null);
    Task<bool> Delete(int id, ITransaction<M>? transaccion = null);

    ITransaction<M> BeginTransaction();
}
