using Ejemplo_CRUD_Simple_Login.Models;
using Microsoft.Data.SqlClient;

namespace EjemploASP.NET_MVC.DALs.MSSDAO;

public class CuentasMSSDAL : ICuentasDAL
{
    string coneccion = "Integrated Security=true; Initial Catalog=EjemploCRUDSimpleLoginDB;Server=TSP;TrustServerCertificate=true;";

    public List<CuentaModel> GetAll()
    {
        var lista = new List<CuentaModel>();
               
        string sqlQuery = 
@"SELECT * 
FROM Cuentas";

        using var conexion = new SqlConnection(coneccion);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);

        var reader = query.ExecuteReader();

        while (reader.Read())
        {
            int id = Convert.ToInt32(reader["Id"]);
            string? name = reader["Nombre"] as string;
            string? password= reader["Clave"] as string;

            var objeto = new CuentaModel {Id=id, Nombre=name, Clave=password };

            lista.Add(objeto);
        }
        return lista;
    }

    public CuentaModel? GetById(int id)
    {
        CuentaModel objeto = null;

        string sqlQuery = 
@"SELECT * 
FROM Cuentas p
WHERE p.Id=@Id";

        using var conexion = new SqlConnection(coneccion);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Id", id);

        var reader = query.ExecuteReader();
        
        if (reader.Read())
        {
            int idG = Convert.ToInt32(reader["Id"]);
            string? name = reader["Nombre"] as string;
            string? password = reader["Clave"] as string;

            objeto = new CuentaModel { Id = idG, Nombre = name, Clave = password };
        }
        return objeto;
    }

    public bool Insert(CuentaModel nuevo)
    {
        string sqlQuery =
@"INSERT Cuentas(Dni, Nombre)
OUTPUT INSERTED.ID 
VALUES (@Nombre, @Clave)"; 

        using var conexion = new SqlConnection(coneccion);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
        query.Parameters.AddWithValue("@Clave", nuevo.Clave);

        nuevo.Id = Convert.ToInt32( query.ExecuteScalar() );
        return nuevo.Id > 0;
    }

    public bool Update(CuentaModel actualizar)
    {
        string sqlQuery =
@"UPDATE Cuentas SET Dni=@Dni, Nombre=@Nombre 
WHERE Id=@Id";

        using var conexion = new SqlConnection(coneccion);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Nombre", actualizar.Nombre);
        query.Parameters.AddWithValue("@Clave", actualizar.Clave);
        query.Parameters.AddWithValue("@Id", actualizar.Id);

        int cantidad=query.ExecuteNonQuery();

        return cantidad > 0;
    }

    public void Delete(int id)
    {
        string sqlQuery =
@"DELETE FROM Cuentas
WHERE Id=@Id";

        using var conexion = new SqlConnection(coneccion);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Id", id);

        var eliminados = query.ExecuteScalar();
    }
}
