using Ejemplo_03_CRUD_Simple_Login.DALs.MSSDALs;
using Ejemplo_03_CRUD_Simple_Login.Models;

using Microsoft.Data.SqlClient;

namespace Ejemplo_03_CRUD_Simple_Login.DALs.MSSDAO;

public class RolesMSSDAL : IRolesDAL
{
    
    public List<RolModel> GetAll()
    {
        var lista = new List<RolModel>();
               
        string sqlQuery = 
@"SELECT * 
FROM Cuentas";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);

        var reader = query.ExecuteReader();

        while (reader.Read())
        {
            int id = Convert.ToInt32(reader["Id"]);
            string? name = reader["Nombre"] as string;

            var objeto = new RolModel {Id=id, Nombre=name };

            lista.Add(objeto);
        }
        return lista;
    }

    public RolModel? GetById(int id)
    {
        RolModel objeto = null;

        string sqlQuery = 
@"SELECT TOP 1 r.* 
FROM Roles r
WHERE r.Id=@Id";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Id", id);

        var reader = query.ExecuteReader();
        
        if (reader.Read())
        {
            int idG = Convert.ToInt32(reader["Id"]);
            string? name = reader["Nombre"] as string;
            string? password = reader["Clave"] as string;

            objeto = new RolModel { Id = idG, Nombre = name };
        }
        return objeto;
    }

    public RolModel? GetByNombre(string nombre)
    {
        RolModel objeto = null;

        string sqlQuery =
@"SELECT TOP 1 r.* 
FROM Roles r
WHERE UPPER(TRIM(r.Nombre)) LIKE UPPER(TRIM(@Nombre))";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Nombre", nombre);

        var reader = query.ExecuteReader();

        if (reader.Read())
        {
            int id = Convert.ToInt32(reader["Id"]);
            string? nom= reader["Nombre"] as string;

            objeto = new RolModel { Id = id, Nombre = nom};
        }
        return objeto;
    }

    public bool Insert(RolModel nuevo)
    {
        string sqlQuery =
@"INSERT Roles(Nombre)
OUTPUT INSERTED.ID 
VALUES (@Nombre)"; 

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Nombre", nuevo.Nombre);

        nuevo.Id = Convert.ToInt32( query.ExecuteScalar() );
        return nuevo.Id > 0;
    }

    public bool Update(RolModel actualizar)
    {
        string sqlQuery =
@"UPDATE Roles SET Nombre=@Nombre 
WHERE Id=@Id";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Nombre", actualizar.Nombre);
        query.Parameters.AddWithValue("@Id", actualizar.Id);

        int cantidad=query.ExecuteNonQuery();

        return cantidad > 0;
    }

    public void Delete(int id)
    {
        string sqlQuery =
@"DELETE FROM Roles
WHERE Id=@Id";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Id", id);

        var eliminados = query.ExecuteScalar();
    }
}
