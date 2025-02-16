using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo_14_Transacciones.DAOs.MSSDALs;

public class SqlServerTransaction : ITransaction<SqlTransaction>
{
    private readonly SqlTransaction _transaccion;

    public SqlServerTransaction(SqlTransaction transaccion)
    {
        _transaccion = transaccion;
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
        await _transaccion.Connection.CloseAsync();
    }

    public async Task RollbackAsync()
    {
        await Task.Run(() => _transaccion.Rollback());
        await _transaccion.Connection.CloseAsync();
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
}
