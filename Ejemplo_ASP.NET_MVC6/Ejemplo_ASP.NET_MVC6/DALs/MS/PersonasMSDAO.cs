using EjemploASP.NET_MVC.Models;
using Microsoft.Data.SqlClient;

namespace EjemploASP.NET_MVC.DALs;

public class PersonasMSDAO : IPersonasDAO
{
    string coneccion = "Integrated Security=true; Initial Catalog=PersonasDB;Server=TSP;TrustServerCertificate=true;";

    public List<Persona> GetAll()
    {
        var lista = new List<Persona>();
               
        string sqlQuery = "SELECT * FROM Personas";

        using var conexion = new SqlConnection(coneccion);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);

        var reader = query.ExecuteReader();

        while (reader.Read())
        {
            int id = Convert.ToInt32(reader["Id"]);
            int dni = Convert.ToInt32(reader["DNI"]);
            string nombre = reader["Nombre"] as string;

            var objeto = new Persona { Id=id, DNI = dni, Nombre = nombre };

            lista.Add(objeto);
        }
        return lista;
    }

    public Persona? GetById(int id)
    {
        Persona persona = null;

        string sqlQuery = 
@"SELECT * 
FROM Personas p
WHERE p.Id=@Id";

        using var conexion = new SqlConnection(coneccion);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Id", id);

        var reader = query.ExecuteReader();
        
        if (reader.Read())
        {
            int _id = Convert.ToInt32(reader["Id"]);
            int dni = Convert.ToInt32(reader["DNI"]);
            string nombre = reader["Nombre"] as string;

            persona = new Persona { Id = _id, DNI = dni, Nombre = nombre };

        }
        return persona;
    }

    public void Update(Persona actualizar)
    {
        string sqlQuery =
@"UPDATE Personas SET Dni=@Dni, Nombre=@Nombre 
WHERE Id=@Id";

        using var conexion = new SqlConnection(coneccion);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Dni", actualizar.DNI);
        query.Parameters.AddWithValue("@Nombre", actualizar.Nombre);
        query.Parameters.AddWithValue("@Id", actualizar.Id);

        int cantidad=query.ExecuteNonQuery();

    }

    public void Delete(int id)
    {
        string sqlQuery =
@"DELETE FROM Personas
WHERE p.Id=@Id";

        using var conexion = new SqlConnection(coneccion);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Id", id);

        var eliminados = query.ExecuteScalar();
    }
}
