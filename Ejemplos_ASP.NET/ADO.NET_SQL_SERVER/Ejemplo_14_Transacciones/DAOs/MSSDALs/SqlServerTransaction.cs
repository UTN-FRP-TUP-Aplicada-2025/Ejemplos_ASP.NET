using Ejemplo_14_Transacciones.MSSDALs;
using Microsoft.Data.SqlClient;

namespace Ejemplo_14_Transacciones.DAOs.MSSDALs;

public class SqlServerTransaction : ITransaction<SqlTransaction>
{
    private SqlTransaction _transaccion;

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
        await Task.Run(() => _transaccion.Commit());
        //await _transaccion.Connection.CloseAsync();
    }

    public async Task RollbackAsync()
    {
        await Task.Run(() => _transaccion.Rollback());
        //await _transaccion?.Connection?.CloseAsync();
    }

    public void Dispose()
    {
        _transaccion.Connection?.Close();
        _transaccion.Dispose();
    }

    public SqlTransaction GetInternalTransaction()
    {
        return _transaccion;
    }

    private SqlConnection ObtenerConexion()
    {
        return new SqlConnection(ConexionString.CadenaConexion);
    }

    async public Task BeginTransaction()
    {
        var conexion = ObtenerConexion();
        await conexion.OpenAsync();

        _transaccion = conexion.BeginTransaction();
    }
}
