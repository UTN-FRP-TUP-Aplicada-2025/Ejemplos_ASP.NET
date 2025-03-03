using Ejemplo_15_personas_datoslib.Models;
using Microsoft.Data.SqlClient;

namespace Ejemplo_15_personas_datoslib.DALs.MSSDALs;

public class RolesMSSDAL : IBaseDAL<RolModel, string, SqlTransaction>
{
    private readonly SqlConnection _sqlConnection;

    public RolesMSSDAL(SqlConnection sqlConnection)
    {
        _sqlConnection = sqlConnection;
    }

    public async Task<List<RolModel>> GetAll(ITransaction<SqlTransaction>? transaccion = null)
    {
        var lista = new List<RolModel>();

        string sqlQuery =
@"SELECT r.* 
FROM Roles r";

        var conexion = await GetOpenedConnectionAsync(transaccion);

        using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());

        using var reader = await query.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            var objeto = ReadAsObjeto(reader);
            lista.Add(objeto);
        }
        return lista;
    }

    async public Task<RolModel?> GetByKey(string nombre, ITransaction<SqlTransaction>? transaccion = null)
    {
        RolModel objeto = null;

        string sqlQuery =
@"SELECT TOP 1 r.* 
FROM Roles r
WHERE r.Nombre=@Nombre"
        ;

        var conexion = await GetOpenedConnectionAsync(transaccion);

        using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
        query.Parameters.AddWithValue("@Nombre", nombre);

        using var reader = await query.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            objeto = ReadAsObjeto(reader);
        }
        return objeto;
    }

    async public Task<bool> Insert(RolModel nuevo, ITransaction<SqlTransaction>? transaccion = null)
    {
        string sqlQuery =
@"INSERT Roles(Nombre)
VALUES (@Nombre)";

        var conexion = await GetOpenedConnectionAsync(transaccion);

        using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
        query.Parameters.AddWithValue("@Nombre", nuevo.Nombre);

        var respuesta = await query.ExecuteNonQueryAsync();
        int cantidad = Convert.ToInt32(respuesta);
        return cantidad > 0;
    }

    async public Task<bool> Update(RolModel actualizar, ITransaction<SqlTransaction>? transaccion = null)
    {
        string sqlQuery =
@"UPDATE Roles SET Nombre=@Nombre
WHERE Nombre=@Nombre";

        var conexion = await GetOpenedConnectionAsync(transaccion);

        using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
        query.Parameters.AddWithValue("@Nombre", actualizar.Nombre);
        
        int cantidad = await query.ExecuteNonQueryAsync();

        return cantidad > 0;
    }

    async public Task<bool> Delete(string nombre, ITransaction<SqlTransaction>? transaccion = null)
    {
        string sqlQuery =
@"DELETE FROM Roles
WHERE Nombre=@Nombre";

        var conexion = await GetOpenedConnectionAsync(transaccion); 
        
        using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
        query.Parameters.AddWithValue("@Nombre", nombre);

        int? eliminados = await query.ExecuteNonQueryAsync();

        return eliminados > 0;
    }

    private async Task<SqlConnection> GetOpenedConnectionAsync(ITransaction<SqlTransaction>? transaccion)
    {
        var conexion = transaccion?.GetInternalTransaction()?.Connection ?? _sqlConnection;
        if (conexion.State == System.Data.ConnectionState.Closed)
        {
            await conexion.OpenAsync();
        }
        return conexion;
    }

    protected RolModel ReadAsObjeto(SqlDataReader reader)
    {
        string nombre = reader["Nombre"] != DBNull.Value ? Convert.ToString(reader["Nombre"]) : "";      
        var objeto = new RolModel { Nombre = nombre };
        return objeto;
    }
}

