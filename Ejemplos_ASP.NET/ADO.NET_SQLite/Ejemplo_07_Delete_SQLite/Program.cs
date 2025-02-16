

using Microsoft.Data.Sqlite;

var personaId = 3;

var cadenaConexion = "Data Source=../../../../Db/Personas_db.db";

var query = 
@"DELETE FROM Personas 
WHERE ID=@Id";          //ojo aquí, si la condición elimina a todos

try
{

    using var conexion = new SqliteConnection(cadenaConexion);   //hace que se cierre
    await conexion.OpenAsync();

    var comando = new SqliteCommand(query, conexion);
    comando.Parameters.AddWithValue("@Id", personaId);

    int eliminados = await comando.ExecuteNonQueryAsync();

    Console.WriteLine($"Cantidad de eliminados: {eliminados} registros");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
