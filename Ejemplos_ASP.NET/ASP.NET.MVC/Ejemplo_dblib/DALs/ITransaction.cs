namespace Ejemplo_15_personas_datoslib.DALs;

public interface ITransaction<T> : IDisposable
{
    void Commit();
    void Rollback();

    Task CommitAsync();

    Task RollbackAsync();

    T GetInternalTransaction();

    Task BeginTransaction();
}
