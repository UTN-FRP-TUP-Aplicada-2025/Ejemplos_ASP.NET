using Ejemplo_01_0_CRUD_MVC_Simple.MSSDALs;
using Ejemplo_01_0_CRUD_MVC_Simple.Models;

using Microsoft.Data.SqlClient;
using Ejemplo_01_0_CRUD_MVC_Simple.DALs;
using Ejemplo_01_0_CRUD_MVC_Simple.DAOs;

namespace Ejemplo_01_0_CRUD_MVC_Simple.DALs.MSSDALs;

public class UsuariosMSSDAL : IBaseDAL<UsuarioModel, string, SqlTransaction>
{
    private SqlConnection ObtenerConexion()
    {
        return new SqlConnection(ConexionString.CadenaConexion);
    }

    async public Task<List<UsuarioModel>> GetAll(ITransaction<SqlTransaction>? transaccion = null)
    {
        var lista = new List<UsuarioModel>();

        string sqlQuery =
@"SELECT u.* 
FROM Usuarios u";

        using var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
        if (transaccion is null)
            await conexion.OpenAsync();

        using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());

        var reader = await query.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            var objeto = ReadAsObjecto(reader);
            lista.Add(objeto);
        }
        return lista;
    }

    async public Task<UsuarioModel?> GetByKey(string nombre, ITransaction<SqlTransaction>? transaccion = null)
    {
        UsuarioModel objeto = null;

        string sqlQuery =
@"SELECT TOP 1 u.* 
FROM Usuarios u
WHERE UPPER(TRIM(u.Nombre)) LIKE UPPER(TRIM(@Nombre))";

        using var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
        if (transaccion is null)
            await conexion.OpenAsync();

        using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
        query.Parameters.AddWithValue("@Nombre", nombre);

        var reader =await query.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            objeto = ReadAsObjecto(reader);
        }
        return objeto;
    }

    async public Task<bool> Insert(UsuarioModel nuevo, ITransaction<SqlTransaction>? transaccion = null)
    {
        string sqlQuery =
@"INSERT Usuarios(Nombre, Clave)
VALUES (@Nombre, @Clave)";

        var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
        if (transaccion is null)
            await conexion.OpenAsync();

        using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
        query.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
        query.Parameters.AddWithValue("@Clave", nuevo.Clave);

        int cantInsertados = Convert.ToInt32(await query.ExecuteNonQueryAsync());
        return cantInsertados > 0;
    }

    async public Task<bool> Update(UsuarioModel actualizar, ITransaction<SqlTransaction>? transaccion = null)
    {
        string sqlQuery =
@"UPDATE Usuarios SET Clave=@Clave
WHERE UPPER(TRIM(Nombre)) LIKE UPPER(@Nombre_Usuario)";

        using var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
        if (transaccion is null)
            await conexion.OpenAsync();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Clave", actualizar.Clave);
        query.Parameters.AddWithValue("@Nombre_Usuario", actualizar.Nombre);

        int cantidad = await query.ExecuteNonQueryAsync();

        return cantidad > 0;
    }

    async public Task<bool> Delete(string nombre, ITransaction<SqlTransaction>? transaccion = null)
    {
        string sqlQuery =
@"DELETE FROM Usuarios
WHERE UPPER(TRIM(Nombre)) LIKE UPPER(@Nombre)";

        using var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
        if (transaccion is null)
            await conexion.OpenAsync();

        using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
        query.Parameters.AddWithValue("@Nombre", nombre);

        int eliminados = await query.ExecuteNonQueryAsync();

        return eliminados > 0;
    }

    protected UsuarioModel ReadAsObjecto(SqlDataReader reader, ITransaction<SqlTransaction>? transaccion = null)
    {
        string nombre = reader["Nombre"] != DBNull.Value ? Convert.ToString(reader["Nombre"]) : "";
        string clave = reader["Clave"] != DBNull.Value ? Convert.ToString(reader["Clave"]) : "";
        
        var objeto = new UsuarioModel { Nombre = nombre,  Clave=clave };

        return objeto;
    }
}
