using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Ejemplo_15_personas_datoslib.DALs.MSSDALs;

public class SqlServerTransaction : ITransaction<SqlTransaction>
{
    private SqlTransaction _transaccion;

    private readonly IConfiguration _configuracion;
    private readonly SqlConnection _sqlConnection;

    public SqlServerTransaction(IConfiguration configuracion, SqlConnection sqlConnection)
    {
        _sqlConnection = sqlConnection ?? throw new ArgumentNullException(nameof(sqlConnection));

        _configuracion = configuracion;
    }

    public void Commit()
    {
        _transaccion.Commit();
    }

    public void Rollback()
    {
        _transaccion.Rollback();
    }

    public async Task CommitAsync()
    {
        if (_transaccion == null)
        {
            throw new InvalidOperationException("Transaction has not been started.");
        }
        await Task.Run(() => _transaccion.Commit());
        //await _transaccion?.Connection?.CloseAsync();
    }

    public async Task RollbackAsync()
    {
        if (_transaccion == null)
        {
            throw new InvalidOperationException("Transaction has not been started.");
        }
        await Task.Run(() => _transaccion.Rollback());
        //await _transaccion.Connection.CloseAsync();
    }

    public void Dispose()
    {
        _transaccion?.Connection?.Close();
        _transaccion?.Dispose();
    }

    public SqlTransaction GetInternalTransaction()
    {
        return _transaccion;
    }

    async public Task BeginTransaction()
    {
        if (_sqlConnection.State != System.Data.ConnectionState.Open)
        {
            await _sqlConnection.OpenAsync();
        }
        _transaccion = _sqlConnection.BeginTransaction();
    }
}
