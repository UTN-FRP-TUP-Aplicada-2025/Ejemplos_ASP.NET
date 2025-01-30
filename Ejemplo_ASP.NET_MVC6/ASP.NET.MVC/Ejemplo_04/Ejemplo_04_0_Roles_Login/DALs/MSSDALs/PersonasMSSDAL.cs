using Ejemplo_04_0_Roles_Login.DALs.MSSDALs;
using Ejemplo_04_0_Roles_Login.Models;

using Microsoft.Data.SqlClient;

namespace Ejemplo_04_0_Roles_Login.DALs.MSSDAO;

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
            var objeto = ReadAsPersona(reader);
            lista.Add(objeto);
        }
        return lista;
    }

    public PersonaModel? GetByKey(int id)
    {
        PersonaModel objeto = null;

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
            objeto = ReadAsPersona(reader);
        }
        return objeto;
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

    public PersonaModel ReadAsPersona(SqlDataReader reader)
    {
        int id = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0;
        int dni = reader["DNI"] != DBNull.Value ? Convert.ToInt32(reader["DNI"]) : 0;
        string nombre = reader["Nombre"] != DBNull.Value ? Convert.ToString(reader["Nombre"]) : "";
        DateTime? nacimiento = reader["Fecha_Nacimiento"] != DBNull.Value ? Convert.ToDateTime(reader["Fecha_Nacimiento"]) : (DateTime?)null;

        var objeto = new PersonaModel { Id = id, DNI = dni, Nombre = nombre, FechaNacimiento = nacimiento };

        return objeto;
    }
}
