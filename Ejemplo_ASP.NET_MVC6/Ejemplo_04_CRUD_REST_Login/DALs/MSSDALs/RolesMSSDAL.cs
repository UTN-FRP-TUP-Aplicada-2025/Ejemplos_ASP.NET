using Ejemplo_04_CRUD_REST_Login.DALs.MSSDALs;
using Ejemplo_04_CRUD_REST_Login.Models;

using Microsoft.Data.SqlClient;

namespace Ejemplo_04_CRUD_REST_Login.DALs.MSSDAO;

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
            string? name = reader["Nombre"] as string;

            var objeto = new RolModel {Nombre=name };

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
            string? nom= reader["Nombre"] as string;

            objeto = new RolModel { Nombre = nombreRol };
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

}
