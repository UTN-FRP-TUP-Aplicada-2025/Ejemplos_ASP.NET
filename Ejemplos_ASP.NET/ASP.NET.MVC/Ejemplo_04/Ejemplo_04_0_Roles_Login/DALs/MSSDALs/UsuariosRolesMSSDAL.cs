using Ejemplo_04_0_Roles_Login.DALs.MSSDALs;
using Ejemplo_04_0_Roles_Login.Models;

using Microsoft.Data.SqlClient;

namespace Ejemplo_04_0_Roles_Login.DALs.MSSDAO;

public class UsuariosRolesMSSDAL : IUsuariosRolesDAL
{
    public List<UsuarioRolModel> GetAll()
    {
        var lista = new List<UsuarioRolModel>();
               
        string sqlQuery =
@"SELECT ur.* 
FROM Usuarios_Roles ur";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);

        var reader = query.ExecuteReader();

        while (reader.Read())
        {
            var objeto = ReadAsUsuarioRol(reader);
            lista.Add(objeto);
        }
        return lista;
    }

    public UsuarioRolModel? GetByKey(UsuarioRolModel usuarioRol)
    {
        UsuarioRolModel? objeto = null;

        string sqlQuery =
@"SELECT TOP 1 ur.* 
FROM Usuarios_Roles ur
WHERE UPPER(TRIM(ur.Nombre_Usuario))=UPPER(TRIM(@Nombre_Usuario)) AND 
        UPPER(TRIM(ur.Nombre_Rol))=UPPER(TRIM(@Nombre_Rol)) ";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Nombre_Usuario", usuarioRol.NombreUsuario);
        query.Parameters.AddWithValue("@Nombre_Rol", usuarioRol.NombreRol);

        var reader = query.ExecuteReader();
        
        if (reader.Read())
        {
            objeto = ReadAsUsuarioRol(reader);
        }
        return objeto;
    }

    public bool Insert(UsuarioRolModel nuevo)
    {
        string sqlQuery =
@"INSERT Usuarios_Roles(Nombre_Cuenta, Nombre_Rol)
VALUES (@Nombre_Usuario, @Nombre_Rol)"; 

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Nombre_Usuario", nuevo.NombreUsuario);
        query.Parameters.AddWithValue("@Nombre_Rol", nuevo.NombreRol);

        int insertados= query.ExecuteNonQuery();
        return insertados > 0;
    }

    public bool Update(UsuarioRolModel actualizar)
    {
        string sqlQuery =
@"UPDATE Usuarios_Roles SET Nombre_Rol=@Nombre_Rol
WHERE Nombre_Usuario=@Nombre_Usuario";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Nombre_Usurio", actualizar.NombreUsuario);
        query.Parameters.AddWithValue("@Nombre_Rol", actualizar.NombreRol);

        int cantidad=query.ExecuteNonQuery();

        return cantidad > 0;
    }

    public void Delete(UsuarioRolModel usuarioRol)
    {
        string sqlQuery =
@"DELETE FROM Usuarios_Roles
WHERE UPPER(TRIM(ur.Nombre_Usuario))=UPPER(TRIM(@Nombre_Usuario)) AND 
        UPPER(TRIM(ur.Nombre_Rol))=UPPER(TRIM(@Nombre_Rol)) ";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Nombre_Usuario", usuarioRol.NombreUsuario);
        query.Parameters.AddWithValue("@Nombre_Rol", usuarioRol.NombreRol);

        var eliminados = query.ExecuteScalar();
    }
    
    public UsuarioRolModel ReadAsUsuarioRol(SqlDataReader reader)
    {
        string usuario = reader["Nombre_Usuario"] != DBNull.Value ? Convert.ToString(reader["Nombre_Usuario"]) : "";
        string rol = reader["Nombre_Rol"] != DBNull.Value ? Convert.ToString(reader["Nombre_Rol"]) : "";
        var objeto = new UsuarioRolModel { NombreUsuario = usuario, NombreRol=rol };
        return objeto;
    }
}
