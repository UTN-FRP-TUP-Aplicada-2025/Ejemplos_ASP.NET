using Ejemplo_13.MSSDALs;
using Ejemplo_13.DALs;
using Ejemplo_13.Models;

using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ejemplo_13.DALs.MSSDALs;

public class RolesMSSDAL : IBaseDAL<RolModel, string>
{
    async public Task<List<RolModel>> GetAll()
    {
        var lista = new List<RolModel>();

        string sqlQuery =
@"SELECT p.* 
FROM Roles p";

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

    async public Task<RolModel?> GetByKey(string nombre)
    {
        RolModel objeto = null;

        string sqlQuery =
@"SELECT TOP 1 r.* 
FROM Roles r
WHERE r.Nombre=@Nombre";

        using var conexion = new SqlConnection(ConexionString.CadenaConexion);
        await conexion.OpenAsync();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Nombre", nombre);

        var reader = await query.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            objeto = ReadAsObjeto(reader);
        }
        return objeto;
    }

    async public Task<bool> Insert(RolModel nuevo)
    {
        string sqlQuery =
@"INSERT Roles(Nombre)
VALUES (@Nombre)";

        using var conexion = new SqlConnection(ConexionString.CadenaConexion);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Nombre", nuevo.Nombre);

        var respuesta = await query.ExecuteNonQueryAsync();
        int cantidad = Convert.ToInt32(respuesta);
        return cantidad > 0;
    }

    async public Task<bool> Update(RolModel actualizar)
    {
        string sqlQuery =
@"UPDATE Roles SET Nombre=@Nombre
WHERE Nombre=@Nombre";

        using var conexion = new SqlConnection(ConexionString.CadenaConexion);
        await conexion.OpenAsync();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Nombre", actualizar.Nombre);
        
        int cantidad = await query.ExecuteNonQueryAsync();

        return cantidad > 0;
    }

    async public Task<bool> Delete(string nombre)
    {
        string sqlQuery =
@"DELETE FROM Roles
WHERE Nombre=@Nombre";

        using var conexion = new SqlConnection(ConexionString.CadenaConexion);
        await conexion.OpenAsync();

        using var query = new SqlCommand(sqlQuery, conexion);
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

