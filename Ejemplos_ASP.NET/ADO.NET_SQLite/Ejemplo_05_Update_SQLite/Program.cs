
using Microsoft.Data.Sqlite;

var personaNombre = "Carlos";
var personaId = 1;

var cadenaConexion = "Data Source=../../../../Db/Personas_db.db";

var query = 
@"UPDATE Personas SET Nombre = @Nombre 
WHERE ID = @ID";

using var conexion = new SqliteConnection(cadenaConexion);   //hace que se cierre
await conexion.OpenAsync();

var comando = new SqliteCommand(query, conexion);
comando.Parameters.AddWithValue("@Nombre", personaNombre);
comando.Parameters.AddWithValue("@ID", personaId);

var cantidad = await comando.ExecuteNonQueryAsync();

Console.WriteLine($"cantidad de registros actualizados: {cantidad}");