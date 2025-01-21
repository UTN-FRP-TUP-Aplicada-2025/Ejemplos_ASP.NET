using Ejemplo_04_CRUD_REST_Login.DALs.MSSDALs;
using Ejemplo_04_CRUD_REST_Login.Models;

using Microsoft.Data.SqlClient;

namespace Ejemplo_04_CRUD_REST_Login.DALs.MSSDAO;

public class PersonasMSSDAL : IPersonasDAL
{
    public List<PersonaModel> GetAll()
    {
        var lista = new List<PersonaModel>();
               
        string sqlQuery = 
@"SELECT p.* 
FROM Personas p";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);

        var reader = query.ExecuteReader();

        while (reader.Read())
        {
            int id = Convert.ToInt32(reader["Id"]);
            int dni = Convert.ToInt32(reader["DNI"]);
            string? nombre = reader["Nombre"] as string;
            DateTime? nacimiento = reader["Fecha_Nacimiento"] as DateTime?;

            var objeto = new PersonaModel { Id=id, DNI = dni, Nombre = nombre, FechaNacimiento=nacimiento };

            lista.Add(objeto);
        }
        return lista;
    }

    public PersonaModel? GetById(int id)
    {
        PersonaModel persona = null;

        string sqlQuery = 
@"SELECT TOP 1 p.* 
FROM Personas p
WHERE p.Id=@Id";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Id", id);

        var reader = query.ExecuteReader();
        
        if (reader.Read())
        {
            int _id = Convert.ToInt32(reader["Id"]);
            int dni = Convert.ToInt32(reader["DNI"]);
            string nombre = reader["Nombre"] as string;
            DateTime? fecha = reader["Fecha_Nacimiento"] as DateTime?;

            persona = new PersonaModel { Id = _id, DNI = dni, Nombre = nombre, FechaNacimiento=fecha };

        }
        return persona;
    }

    public bool Insert(PersonaModel nuevo)
    {
        string sqlQuery =
@"INSERT Personas(Dni, Nombre, Fecha_Nacimiento)
OUTPUT INSERTED.ID 
VALUES (@Dni, @Nombre, @Fecha_Nacimiento)"; 

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Dni", nuevo.DNI);
        query.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
        query.Parameters.AddWithValue("@Fecha_Nacimiento", nuevo.FechaNacimiento);

        var respuesta = query.ExecuteScalar();
        nuevo.Id = Convert.ToInt32(respuesta);
        return nuevo.Id > 0;
    }

    public bool Update(PersonaModel actualizar)
    {
        string sqlQuery =
@"UPDATE Personas SET Dni=@Dni, Nombre=@Nombre, Fecha_Nacimiento=@Fecha_Nacimiento 
WHERE Id=@Id";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Dni", actualizar.DNI);
        query.Parameters.AddWithValue("@Nombre", actualizar.Nombre);
        query.Parameters.AddWithValue("@Fecha_Nacimiento", actualizar.FechaNacimiento);
        query.Parameters.AddWithValue("@Id", actualizar.Id);

        int cantidad=query.ExecuteNonQuery();

        return cantidad > 0;
    }

    public void Delete(int id)
    {
        string sqlQuery =
@"DELETE FROM Personas
WHERE Id=@Id";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Id", id);

        var eliminados = query.ExecuteScalar();
    }
}
