
using Microsoft.Data.SqlClient;
using System.Data;

namespace Ejemplo_15_personas_datoslib.Common;

public class TransactionInterceptor
{
    private readonly SqlConnection _connection;

    public TransactionInterceptor(SqlConnection connection)
    {
        _connection = connection;
    }

    public async Task<TResult> ExecuteWithTransaction<TResult>(Func<Task<TResult>> action, TransactionAttribute transactionAttribute)
    {
        SqlTransaction transaction = null;

        try
        {
            if (_connection.State != ConnectionState.Open)
                await _connection.OpenAsync();

            // Iniciar transacción
            transaction = _connection.BeginTransaction();

            // Ejecutar la acción dentro de la transacción
            var result = await action();

            // Si la acción fue exitosa, hacer commit
            transaction.Commit();

            return result;
        }
        catch (Exception ex)
        {
            // Verificar si la excepción es una que debe causar rollback
            if (ShouldRollback(ex, transactionAttribute))
            {
                transaction?.Rollback();
            }
            throw;  // Vuelve a lanzar la excepción
        }
        finally
        {
            // Cerrar la conexión al final
            transaction?.Dispose();
            if (_connection.State != ConnectionState.Closed)
                _connection.Close();
        }
    }

    private bool ShouldRollback(Exception ex, TransactionAttribute transactionAttribute)
    {
        // Lógica para determinar si debemos hacer rollback según el tipo de excepción
        // Por ejemplo, si la excepción es de un tipo específico
        if (transactionAttribute.RollbackFor == "Exception" && ex is Exception)
        {
            return true;
        }
        return false;
    }
}
