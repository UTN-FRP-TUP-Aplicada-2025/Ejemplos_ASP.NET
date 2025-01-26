using Ejemplo_04_CRUD_REST_Login.DALs.MSSDALs;
using Ejemplo_04_CRUD_REST_Login.Models;

using Microsoft.Data.SqlClient;

namespace Ejemplo_04_CRUD_REST_Login.DALs.MSSDAO;

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
            string nombreUsuario = reader["Nombre_Usuario"] as string;
            string nombreRol = reader["Nombre_Rol"] as string;

            var objeto = new UsuarioRolModel { NombreUsuario=nombreUsuario, NombreRol=nombreRol };

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
            string nombreUsuarioBD = reader["Nombre_Usuario"] as string;
            string nombreRolBD = reader["Nombre_Rol"] as string;

            objeto = new UsuarioRolModel { NombreUsuario = nombreUsuarioBD, NombreRol = nombreRolBD };
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

}
