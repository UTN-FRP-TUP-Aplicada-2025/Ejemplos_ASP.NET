using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Ejemplo_15_personas_datoslib.DALs.MSSDALs;

public class SqlServerTransaction : ITransaction<SqlTransaction>
{
    private SqlTransaction _transaccion;

    private readonly IConfiguration _configuracion;

    public SqlServerTransaction(IConfiguration configuracion)
    {
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
        return new SqlConnection(_configuracion.GetConnectionString("CadenaConexion"));
    }

    async public Task BeginTransaction()
    {
        var conexion = ObtenerConexion();
        await conexion.OpenAsync();

        _transaccion = conexion.BeginTransaction();
    }
}
