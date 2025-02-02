using Ejemplo_05_0_Areas.Models;

using Microsoft.Data.SqlClient;

namespace Ejemplo_05_0_Areas.DALs.MSSDALs;

public class PersonasMSSDAL : IPersonasDAL
{
    async public Task<List<PersonaModel>> GetAll()
    {
        var lista = new List<PersonaModel>();

        string sqlQuery =
@"SELECT p.* 
FROM Personas p";

        using var conexion = new SqlConnection(ConexionString.Valor);
        await conexion.OpenAsync();

        using var query = new SqlCommand(sqlQuery, conexion);

        var reader =await query.ExecuteReaderAsync();

        while ( await reader.ReadAsync())
        {
            var objeto = ReadAsPersona(reader);
            lista.Add(objeto);
        }
        return lista;
    }

    async public Task<PersonaModel?> GetByKey(int id)
    {
        PersonaModel objeto = null;

        string sqlQuery =
@"SELECT TOP 1 p.* 
FROM Personas p
WHERE p.Id=@Id";

        using var conexion = new SqlConnection(ConexionString.Valor);
        await conexion.OpenAsync();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Id", id);

        var reader = await query.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            objeto = ReadAsPersona(reader);
        }
        return objeto;
    }

    async public Task<bool> Insert(PersonaModel nuevo)
    {
        string sqlQuery =
@"INSERT Personas(Dni, Nombre, Fecha_Nacimiento)
OUTPUT INSERTED.ID 
VALUES (@Dni, @Nombre, @Fecha_Nacimiento)";

        using var conexion = new SqlConnection(ConexionString.Valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Dni", nuevo.DNI);
        query.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
        query.Parameters.AddWithValue("@Fecha_Nacimiento", nuevo.FechaNacimiento);

        var respuesta =await query.ExecuteScalarAsync();
        nuevo.Id = Convert.ToInt32(respuesta);
        return nuevo.Id > 0;
    }

    async public Task<bool> Update(PersonaModel actualizar)
    {
        string sqlQuery =
@"UPDATE Personas SET Dni=@Dni, Nombre=@Nombre, Fecha_Nacimiento=@Fecha_Nacimiento 
WHERE Id=@Id";

        using var conexion = new SqlConnection(ConexionString.Valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Dni", actualizar.DNI);
        query.Parameters.AddWithValue("@Nombre", actualizar.Nombre);
        query.Parameters.AddWithValue("@Fecha_Nacimiento", actualizar.FechaNacimiento);
        query.Parameters.AddWithValue("@Id", actualizar.Id);

        int cantidad =await query.ExecuteNonQueryAsync();

        return cantidad > 0;
    }

    async public Task<bool> Delete(int id)
    {
        string sqlQuery =
@"DELETE FROM Personas
WHERE Id=@Id";

        using var conexion = new SqlConnection(ConexionString.Valor);
        await conexion.OpenAsync();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Id", id);

        int? eliminados = await query.ExecuteNonQueryAsync();

        return eliminados > 0;
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
