

using Microsoft.Data.Sqlite;

var personaId = 2;

var cadenaConexion = "Data Source=../../../../Db/Personas_db.db";

var query = 
@"DELETE Personas 
WHERE ID=@Id;";          //ojo aquí, si la condición elimina a todos

using var conexion = new SqliteConnection(cadenaConexion);   //hace que se cierre
await   conexion.OpenAsync();

var comando = new SqliteCommand(query, conexion);
comando.Parameters.AddWithValue("@ID", personaId);

int eliminados=await comando.ExecuteNonQueryAsync();

Console.WriteLine($"Cantidad de eliminados: {eliminados} registros");
