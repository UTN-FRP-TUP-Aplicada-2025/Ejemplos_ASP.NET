using Ejemplo_04_0_Roles_Login.DALs.MSSDALs;
using Ejemplo_04_0_Roles_Login.Models;

using Microsoft.Data.SqlClient;

namespace Ejemplo_04_0_Roles_Login.DALs.MSSDAO;

public class RolesMSSDAL : IRolesDAL
{
    public List<RolModel> GetAll()
    {
        var lista = new List<RolModel>();
               
        string sqlQuery = 
@"SELECT r.* 
FROM Roles r";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);

        var reader = query.ExecuteReader();

        while (reader.Read())
        {
            var objeto = ReadAsRol(reader);
            lista.Add(objeto);
        }
        return lista;
    }

    public RolModel? GetByKey(string nombreRol)
    {
        RolModel objeto = null;

        string sqlQuery =
@"SELECT TOP 1 r.* 
FROM Roles r
WHERE UPPER(TRIM(r.Nombre)) LIKE UPPER(TRIM(@Nombre_Rol))";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Nombre_Rol", nombreRol);

        var reader = query.ExecuteReader();

        if (reader.Read())
        {
            objeto = ReadAsRol(reader);
        }
        return objeto;
    }

    public bool Insert(RolModel nuevo)
    {
        string sqlQuery =
@"INSERT Roles(Nombre)
VALUES (@Nombre)"; 

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Nombre", nuevo.Nombre);

        int cantidadActualizados= Convert.ToInt32( query.ExecuteNonQuery() );
        return cantidadActualizados > 0;
    }

    public bool Update(RolModel actualizar)
    {
        string sqlQuery =
@"UPDATE Roles SET Nombre=@Nombre_Rol
WHERE Nombre=@Nombre_Rol";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Nombre_Rol", actualizar.Nombre);

        int cantidad=query.ExecuteNonQuery();

        return cantidad > 0;
    }

    public void Delete(string nombreRol)
    {
        string sqlQuery =
@"DELETE FROM Roles
WHERE UPPER(Nombre)=UPPER(@Nombre_Rol)";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Nombre_Rol", nombreRol);

        var eliminados = query.ExecuteScalar();
    }

    public RolModel ReadAsRol(SqlDataReader reader)
    {
        string nombre = reader["Nombre"] != DBNull.Value ? Convert.ToString(reader["Nombre"]) : "";
        var objeto = new RolModel { Nombre = nombre };
        return objeto;
    }
}
