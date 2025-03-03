using Ejemplo_13.MSSDALs;
using Ejemplo_13.Models;

using Microsoft.Data.SqlClient;

namespace Ejemplo_13.DALs.MSSDALs;

public class UsuariosMSSDAL : IBaseDAL<UsuarioModel, string>
{
    async public Task<List<UsuarioModel>> GetAll()
    {
        var lista = new List<UsuarioModel>();

        string sqlQuery =
@"SELECT u.* 
FROM Usuarios u";

        using var conexion = new SqlConnection(ConexionString.CadenaConexion);
        await conexion.OpenAsync();

        using var query = new SqlCommand(sqlQuery, conexion);

        var reader = await query.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            var objeto = ReadAsObjeto(reader);
            lista.Add(objeto);
        }
        return lista;
    }

    async public Task<UsuarioModel?> GetByKey(string nombre)
    {
        UsuarioModel objeto = null;

        string sqlQuery =
@"SELECT TOP 1 u.* 
FROM Usuarios u
WHERE UPPER(TRIM(u.Nombre)) LIKE UPPER(TRIM(@Nombre))";

        using var conexion = new SqlConnection(ConexionString.CadenaConexion);
        await conexion.OpenAsync();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Nombre", nombre);

        var reader =await query.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            objeto = ReadAsObjeto(reader);
        }
        return objeto;
    }

    async public Task<bool> Insert(UsuarioModel nuevo)
    {
        string sqlQuery =
@"INSERT Usuarios(Nombre, Clave)
VALUES (@Nombre, @Clave)";

        using var conexion = new SqlConnection(ConexionString.CadenaConexion);
        await conexion.OpenAsync();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
        query.Parameters.AddWithValue("@Clave", nuevo.Clave);

        int cantInsertados = Convert.ToInt32(await query.ExecuteNonQueryAsync());
        return cantInsertados > 0;
    }

    async public Task<bool> Update(UsuarioModel actualizar)
    {
        string sqlQuery =
@"UPDATE Usuarios SET Clave=@Clave
WHERE UPPER(TRIM(Nombre)) LIKE UPPER(@Nombre_Usuario)";

        using var conexion = new SqlConnection(ConexionString.CadenaConexion);
        await conexion.OpenAsync();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Clave", actualizar.Clave);
        query.Parameters.AddWithValue("@Nombre_Usuario", actualizar.Nombre);

        int cantidad = await query.ExecuteNonQueryAsync();

        return cantidad > 0;
    }

    async public Task<bool> Delete(string nombre)
    {
        string sqlQuery =
@"DELETE FROM Usuarios
WHERE UPPER(TRIM(Nombre)) LIKE UPPER(@Nombre)";

        using var conexion = new SqlConnection(ConexionString.CadenaConexion);
        await conexion.OpenAsync();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Nombre", nombre);

        int eliminados = await query.ExecuteNonQueryAsync();

        return eliminados > 0;
    }

    protected UsuarioModel ReadAsObjeto(SqlDataReader reader)
    {
        string nombre = reader["Nombre"] != DBNull.Value ? Convert.ToString(reader["Nombre"]) : "";
        string clave = reader["Clave"] != DBNull.Value ? Convert.ToString(reader["Clave"]) : "";
        
        var objeto = new UsuarioModel { Nombre = nombre,  Clave=clave };

        return objeto;
    }
}
