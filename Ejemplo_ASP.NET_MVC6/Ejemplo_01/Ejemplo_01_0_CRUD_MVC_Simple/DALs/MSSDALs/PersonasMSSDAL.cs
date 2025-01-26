using Ejemplo_01_0_CRUD_MVC_Simple.Models;

using Microsoft.Data.SqlClient;

namespace Ejemplo_01_0_CRUD_MVC_Simple.DALs.MSSDALs;

public class PersonasMSSDAL : IPersonasDAL
{
    public List<PersonaModel> GetAll()
    {
        var lista = new List<PersonaModel>();
               
        string sqlQuery = 
@"SELECT p.* 
FROM Personas p";

        using var conexion = new SqlConnection(ConexionString.Valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);

        var reader = query.ExecuteReader();

        while (reader.Read())
        {
            int id = Convert.ToInt32(reader["Id"]);
            int dni = Convert.ToInt32(reader["DNI"]);
            string nombre = reader["Nombre"] as string;

            var objeto = new PersonaModel { Id=id, DNI = dni, Nombre = nombre };

            lista.Add(objeto);
        }
        return lista;
    }

    public PersonaModel? GetByKey(int id)
    {
        PersonaModel persona = null;

        string sqlQuery = 
@"SELECT p.* 
FROM Personas p
WHERE p.Id=@Id";

        using var conexion = new SqlConnection(ConexionString.Valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Id", id);

        var reader = query.ExecuteReader();
        
        if (reader.Read())
        {
            int _id = Convert.ToInt32(reader["Id"]);
            int dni = Convert.ToInt32(reader["DNI"]);
            string nombre = reader["Nombre"] as string;

            persona = new PersonaModel { Id = _id, DNI = dni, Nombre = nombre };

        }
        return persona;
    }

    public bool Insert(PersonaModel nuevo)
    {
        string sqlQuery =
@"INSERT Personas(Dni, Nombre)
OUTPUT INSERTED.ID 
VALUES (@Dni, @Nombre)"; 

        using var conexion = new SqlConnection(ConexionString.Valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Dni", nuevo.DNI);
        query.Parameters.AddWithValue("@Nombre", nuevo.Nombre);

        nuevo.Id = Convert.ToInt32( query.ExecuteScalar() );
        return nuevo.Id > 0;
    }

    public bool Update(PersonaModel actualizar)
    {
        string sqlQuery =
@"UPDATE Personas SET Dni=@Dni, Nombre=@Nombre 
WHERE Id=@Id";

        using var conexion = new SqlConnection(ConexionString.Valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Dni", actualizar.DNI);
        query.Parameters.AddWithValue("@Nombre", actualizar.Nombre);
        query.Parameters.AddWithValue("@Id", actualizar.Id);

        int cantidad=query.ExecuteNonQuery();

        return cantidad > 0;
    }

    public void Delete(int id)
    {
        string sqlQuery =
@"DELETE FROM Personas
WHERE Id=@Id";

        using var conexion = new SqlConnection(ConexionString.Valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Id", id);

        var eliminados = query.ExecuteScalar();
    }
}
