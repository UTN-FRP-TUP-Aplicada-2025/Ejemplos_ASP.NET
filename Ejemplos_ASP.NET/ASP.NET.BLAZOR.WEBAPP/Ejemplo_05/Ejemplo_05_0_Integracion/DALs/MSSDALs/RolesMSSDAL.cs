using Ejemplo_05_0_Integracion.DAOs;
using Ejemplo_05_0_Integracion.Models;
using Ejemplo_05_0_Integracion.MSSDALs;
using Microsoft.Data.SqlClient;

namespace Ejemplo_05_0_Integracion.DALs.MSSDALs;

public class RolesMSSDAL : IBaseDAL<RolModel, string, SqlTransaction>
{
    private SqlConnection ObtenerConexion()
    {
        return new SqlConnection(ConexionString.CadenaConexion);
    }

    public async Task<List<RolModel>> GetAll(ITransaction<SqlTransaction>? transaccion = null)
    {
        var lista = new List<RolModel>();

        string sqlQuery =
@"SELECT r.* 
FROM Roles r";

        var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
        if (transaccion is null)
            await conexion.OpenAsync();

        using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());

        var reader = await query.ExecuteReaderAsync();
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

        var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
        if (transaccion is null)
            await conexion.OpenAsync();

        using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
        query.Parameters.AddWithValue("@Nombre", nombre);

        var reader = await query.ExecuteReaderAsync();

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

        var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
        if (transaccion is null)
            await conexion.OpenAsync();

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

        var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
        if (transaccion is null)
            await conexion.OpenAsync();

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

        var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
        if (transaccion is null)
            await conexion.OpenAsync();

        using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
        query.Parameters.AddWithValue("@Nombre", nombre);

        int? eliminados = await query.ExecuteNonQueryAsync();

        return eliminados > 0;
    }

    protected RolModel ReadAsObjeto(SqlDataReader reader)
    {
        string nombre = reader["Nombre"] != DBNull.Value ? Convert.ToString(reader["Nombre"]) : "";
      
        var objeto = new RolModel { Nombre = nombre };

        return objeto;
    }

    
}

