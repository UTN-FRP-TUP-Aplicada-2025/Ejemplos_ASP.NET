namespace Ejemplo_01_0_CRUD_MVC_Simple.DAOs;

public interface ITransaction<T> : IDisposable
{
    void Commit();
    void Rollback();

    Task CommitAsync();

    Task RollbackAsync();

    T GetInternalTransaction();

    Task BeginTransaction();
}
