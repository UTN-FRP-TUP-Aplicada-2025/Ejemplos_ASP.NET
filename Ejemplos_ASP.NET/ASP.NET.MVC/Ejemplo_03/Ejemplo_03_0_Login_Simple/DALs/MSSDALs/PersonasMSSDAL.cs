using Ejemplo_03_0_Login_Simple.DAOs;
using Ejemplo_03_0_Login_Simple.Models;
using Microsoft.Data.SqlClient;

namespace Ejemplo_03_0_Login_Simple.DALs.MSSDALs;

public class PersonasMSSDAL : IBaseDAL<PersonaModel, int, SqlTransaction>
{
    private readonly IConfiguration _configuracion;

    public PersonasMSSDAL(IConfiguration configuracion)
    {
        _configuracion = configuracion;
    }

    private SqlConnection ObtenerConexion()
    {
        return new SqlConnection(_configuracion.GetConnectionString("CadenaConexion"));
    }

    public async Task<List<PersonaModel>> GetAll(ITransaction<SqlTransaction>? transaccion = null)
    {
        var lista = new List<PersonaModel>();

        string sqlQuery = 
@"SELECT p.* 
FROM Personas p";

        var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
        if (transaccion is null)
            await conexion.OpenAsync();

        using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());

        var reader = await query.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            var objeto = ReadAsObjeto(reader);
            lista.Add(objeto);
        }
        return lista;
    }

    public async Task<PersonaModel?> GetByKey(int id, ITransaction<SqlTransaction>? transaccion = null)
    {
        PersonaModel? objeto = null;

        string sqlQuery = 
@"
SELECT TOP 1 p.* 
FROM Personas p
WHERE p.Id = @Id";

        var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
        if (transaccion == null)
            await conexion.OpenAsync();

        using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
        query.Parameters.AddWithValue("@Id", id);

        var reader = await query.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            objeto = ReadAsObjeto(reader);
        }
        return objeto;
    }

    public async Task<bool> Insert(PersonaModel nuevo, ITransaction<SqlTransaction>? transaccion = null)
    {
        string sqlQuery = 
@"
INSERT INTO Personas (Dni, Nombre, Fecha_Nacimiento)
OUTPUT INSERTED.ID 
VALUES (@Dni, @Nombre, @Fecha_Nacimiento)";

        var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
        if (transaccion == null)
        {
            await conexion.OpenAsync();
        }

        using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
        query.Parameters.AddWithValue("@Dni", nuevo.DNI);
        query.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
        query.Parameters.AddWithValue("@Fecha_Nacimiento", nuevo.FechaNacimiento);

        var respuesta = await query.ExecuteScalarAsync();
        nuevo.Id = Convert.ToInt32(respuesta);
        return nuevo.Id > 0;
    }

    public async Task<bool> Update(PersonaModel actualizar, ITransaction<SqlTransaction>? transaccion = null)
    {
        string sqlQuery = @"
            UPDATE Personas 
            SET Dni = @Dni, Nombre = @Nombre, Fecha_Nacimiento = @Fecha_Nacimiento 
            WHERE Id = @Id"
        ;

        var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
        if (transaccion == null)
        {
            await conexion.OpenAsync();
        }

        using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
        query.Parameters.AddWithValue("@Dni", actualizar.DNI);
        query.Parameters.AddWithValue("@Nombre", actualizar.Nombre);
        query.Parameters.AddWithValue("@Fecha_Nacimiento", actualizar.FechaNacimiento);
        query.Parameters.AddWithValue("@Id", actualizar.Id);

        int cantidad = await query.ExecuteNonQueryAsync();
        return cantidad > 0;
    }

    public async Task<bool> Delete(int id, ITransaction<SqlTransaction>? transaccion = null)
    {
        string sqlQuery = 
@"
DELETE FROM Personas
WHERE Id = @Id";

        var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
        if (transaccion == null)
        {
            await conexion.OpenAsync();
        }

        using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
        query.Parameters.AddWithValue("@Id", id);

        int eliminados = await query.ExecuteNonQueryAsync();
        return eliminados > 0;
    }


    private PersonaModel ReadAsObjeto(SqlDataReader reader)
    {
        int id = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0;
        int dni = reader["DNI"] != DBNull.Value ? Convert.ToInt32(reader["DNI"]) : 0;
        string nombre = reader["Nombre"] != DBNull.Value ? Convert.ToString(reader["Nombre"]) : "";
        DateTime? nacimiento = reader["Fecha_Nacimiento"] != DBNull.Value
            ? Convert.ToDateTime(reader["Fecha_Nacimiento"])
            : (DateTime?)null;

        return new PersonaModel
        {
            Id = id,
            DNI = dni,
            Nombre = nombre,
            FechaNacimiento = nacimiento
        };
    }
}
