
namespace Ejemplo_14_Transacciones.DAOs;

public interface ITransaction<T> : IDisposable
{
    void Commit();
    void Rollback();

    T GetInternalTransaction();
}
