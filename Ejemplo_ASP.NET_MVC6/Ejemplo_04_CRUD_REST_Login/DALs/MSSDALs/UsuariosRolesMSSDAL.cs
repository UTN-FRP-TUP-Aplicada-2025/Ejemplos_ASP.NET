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
            int idUsuario = Convert.ToInt32(reader["Id_Usuario"]);
            int idRol = Convert.ToInt32(reader["Id_Rol"]);

            var objeto = new UsuarioRolModel { IdUsuario=idUsuario, IdRol=idRol };

            lista.Add(objeto);
        }
        return lista;
    }

    public UsuarioRolModel? GetById(int id)
    {
        UsuarioRolModel? objeto = null;

        string sqlQuery =
@"SELECT TOP 1 ur.* 
FROM Usuarios_Roles ur
WHERE ur.Id=@Id";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Id", id);

        var reader = query.ExecuteReader();
        
        if (reader.Read())
        {
            int idUsuario = Convert.ToInt32(reader["Id_Rol"]);
            int idRol = Convert.ToInt32(reader["Id_Usuario"]);

            objeto = new UsuarioRolModel { IdUsuario = idUsuario, IdRol = idRol };
        }
        return objeto;
    }

    public bool Insert(UsuarioRolModel nuevo)
    {
        string sqlQuery =
@"INSERT Usuarios_Roles(Id_Cuenta, Id_Rol)
VALUES (@Id_Usuario, @Id_Rol)"; 

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Id_Usuario", nuevo.IdUsuario);
        query.Parameters.AddWithValue("@Id_Rol", nuevo.IdRol);

        int insertados= query.ExecuteNonQuery();
        return insertados > 0;
    }

    public bool Update(UsuarioRolModel actualizar)
    {
        string sqlQuery =
@"UPDATE Usuarios_Roles SET Id_Rol=@Id_Rol
WHERE Id_Usuario=@Id_Usuario";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Id_Usurio", actualizar.IdUsuario);
        query.Parameters.AddWithValue("@Id_Rol", actualizar.IdRol);

        int cantidad=query.ExecuteNonQuery();

        return cantidad > 0;
    }

    public void Delete(int id)
    {
        string sqlQuery =
@"DELETE FROM Usuarios_Roles
WHERE Id_Usuario=@Id_Usuario";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Id_Usuario", id);

        var eliminados = query.ExecuteScalar();
    }

}
