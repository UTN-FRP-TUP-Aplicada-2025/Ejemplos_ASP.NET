



using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;

string conectionString = $"Data Source=mydatabase.db;Version=3;";

using var connection = new SqliteConnection(conectionString) ;

await connection.OpenAsync();

var query =
@"SELECT p.* 
FROM Personas p
WHERE UPPER(p.Nombre) LIKE 'UPPER(@Nombre)' ";//normalizando los nombres

using var conexion = new SqliteConnection(conectionString);

await conexion.OpenAsync();

using var comando = new SqliteCommand(query, conexion);
comando.Parameters.AddWithValue("@Nombre", "%ma%");

var reader = await comando.ExecuteReaderAsync();

Console.WriteLine($"{"Id",10}|{"DNI",10}|{"Nombre",30}|{"Fecha",10}");
Console.WriteLine($"----------------------------------------------");
while (await reader.ReadAsync())
{
    int id = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0;
    int dni = reader["DNI"] != DBNull.Value ? Convert.ToInt32(reader["DNI"]) : 0;
    string nombre = reader["Nombre"] != DBNull.Value ? Convert.ToString(reader["Nombre"]) : "";
    DateTime? nacimiento = reader["Fecha_Nacimiento"] != DBNull.Value ? Convert.ToDateTime(reader["Fecha_Nacimiento"]) : (DateTime?)null;

    Console.WriteLine($"{id,10}|{dni,10}|{nombre,30}|{nacimiento,10}");
}
