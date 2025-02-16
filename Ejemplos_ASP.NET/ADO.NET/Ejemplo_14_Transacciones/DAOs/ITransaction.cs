
using Microsoft.Data.SqlClient;
using System.Transactions;

namespace Ejemplo_14_Transacciones.DAOs;

public interface ITransaction<T> : IDisposable
{
    void Commit();
    void Rollback();

    Task CommitAsync();

    Task RollbackAsync();

    T GetInternalTransaction();

    Task BeginTransaction();
}
