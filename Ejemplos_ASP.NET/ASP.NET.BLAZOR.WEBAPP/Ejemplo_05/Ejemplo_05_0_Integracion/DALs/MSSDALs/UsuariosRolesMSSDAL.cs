using Ejemplo_05_0_Integracion.MSSDALs;
using Ejemplo_05_0_Integracion.Models;

using Microsoft.Data.SqlClient;
using Ejemplo_05_0_Integracion.DAOs;

namespace Ejemplo_05_0_Integracion.DALs.MSSDALs;

/*
 muchos metodos tienen sentido si la relacion usuario rol tuviera campos adicionales, como por ejemplo fecha de alta, fecha de baja, etc.
 */

public class UsuariosRolesMSSDAL : IBaseDAL<UsuarioRolModel, UsuarioRolModel, SqlTransaction>
{
    private SqlConnection ObtenerConexion()
    {
        return new SqlConnection(ConexionString.CadenaConexion);
    }

    async public Task<List<UsuarioRolModel>> GetAll(ITransaction<SqlTransaction>? transaccion = null)
    {
        var lista = new List<UsuarioRolModel>();

        string sqlQuery =
@"SELECT u_r.* 
FROM Usuarios_Roles u_r ";

        var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
        if (transaccion is null)
            await conexion.OpenAsync();

        using var query = new SqlCommand(sqlQuery, conexion);

        var reader = await query.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            var objeto = ReadAsObjecto(reader);
            lista.Add(objeto);
        }
        return lista;
    }

    async public Task<UsuarioRolModel?> GetByKey(UsuarioRolModel usuarioRol, ITransaction<SqlTransaction>? transaccion = null)
    {
        UsuarioRolModel objeto = null;

        string sqlQuery =
@"SELECT TOP 1 u_r.* 
FROM Usuarios_Roles u_r
WHERE UPPER(TRIM(u_r.Nombre_Usuario)) LIKE UPPER(TRIM(@NombreUsuario))
        AND UPPER(TRIM(u_r.Nombre_Rol)) LIKE UPPER(TRIM(@NombreRol))";

        var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
        if (transaccion is null)
            await conexion.OpenAsync();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@NombreUsuario", usuarioRol?.NombreUsuario);
        query.Parameters.AddWithValue("@NombreRol", usuarioRol?.NombreRol);

        var reader =await query.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            objeto = ReadAsObjecto(reader);
        }
        return objeto;
    }

    async public Task<List<UsuarioRolModel?>> GetByUsuario(UsuarioRolModel usuarioRol, ITransaction<SqlTransaction>? transaccion = null)
    {
        List<UsuarioRolModel> objetos = new List<UsuarioRolModel>();

        string sqlQuery =
@"SELECT u_r.* 
FROM Usuarios_Roles u_r
WHERE UPPER(TRIM(u_r.Nombre_Usuario)) LIKE UPPER(TRIM(@NombreUsuario))
        AND UPPER(TRIM(u_r.Nombre_Rol)) LIKE UPPER(TRIM(@NombreRol))";

        var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
        if (transaccion is null)
            await conexion.OpenAsync();

        using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
        query.Parameters.AddWithValue("@NombreUsuario", usuarioRol?.NombreUsuario);
        query.Parameters.AddWithValue("@NombreRol", usuarioRol?.NombreRol);

        var reader = await query.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            var objeto = ReadAsObjecto(reader);
            objetos.Add(objeto);
        }
        return objetos;
    }

    async public Task<bool> Insert(UsuarioRolModel nuevo, ITransaction<SqlTransaction>? transaccion = null)
    {
        string sqlQuery =
@"INSERT Usuarios_Roles(Nombre_Usuario, Nombre_Rol)
VALUES (@NombreUsuario, @NombreRol)";

        var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
        if (transaccion is null)
            await conexion.OpenAsync();

        using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
        query.Parameters.AddWithValue("@NombreUsuario", nuevo.NombreUsuario);
        query.Parameters.AddWithValue("@NombreRol", nuevo.NombreRol);

        int cantInsertados = Convert.ToInt32(await query.ExecuteNonQueryAsync());
        return cantInsertados > 0;
    }

    async public Task<bool> Update(UsuarioRolModel actualizar, ITransaction<SqlTransaction>? transaccion = null)
    {
        string sqlQuery =
@"UPDATE Usuarios_Roles SET Nombre_Usuario=@Nombre_Usuario, Nombre_Rol=@Nombre_Rol
WHERE UPPER(TRIM(Nombre_Usuario)) LIKE UPPER(@NombreUsuario) 
        AND UPPER(TRIM(Nombre_Rol)) LIKE UPPER(@NombreRol)";

        var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
        if (transaccion is null)
            await conexion.OpenAsync();

        using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
        query.Parameters.AddWithValue("@NombreUsuario", actualizar.NombreUsuario);
        query.Parameters.AddWithValue("@NombreRol", actualizar.NombreRol);

        int cantidad = await query.ExecuteNonQueryAsync();

        return cantidad > 0;
    }

    async public Task<bool> Delete(UsuarioRolModel usuarioRol, ITransaction<SqlTransaction>? transaccion = null)
    {
        string sqlQuery =
@"DELETE FROM Usuarios_Roles
WHERE UPPER(TRIM(Nombre_Usuario)) LIKE UPPER(@NombreUsuario)
         AND UPPER(TRIM(Nombre_Rol)) LIKE UPPER(@NombreRol)
";

        var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
        if (transaccion is null)
            await conexion.OpenAsync();

        using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
        query.Parameters.AddWithValue("@NombreUsuario", usuarioRol.NombreUsuario);
        query.Parameters.AddWithValue("@NombreRol", usuarioRol.NombreRol);

        int eliminados = await query.ExecuteNonQueryAsync();

        return eliminados > 0;
    }

    protected UsuarioRolModel ReadAsObjecto(SqlDataReader reader)
    {
        string nombreUsuario = reader["Nombre_Usuario"] != DBNull.Value ? Convert.ToString(reader["Nombre_Usuario"]) : "";
        string nombreRol = reader["Nombre_Rol"] != DBNull.Value ? Convert.ToString(reader["Nombre_Rol"]) : "";

        var objeto = new UsuarioRolModel { NombreUsuario = nombreUsuario,  NombreRol=nombreRol };

        return objeto;
    }
}
