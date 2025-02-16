using Microsoft.Data.Sqlite;


var dni = 27712333;
var personaNombre = "Andrea";
var fechaNacimiento = new DateTime(1990, 10, 10);

var cadenaConexion = "Data Source=../../../../Db/Personas_db.db";

var query =
@"INSERT INTO Personas (DNI, Nombre, Fecha_Nacimiento) 
  VALUES (@DNI,@Nombre,@FechaNacimiento)";

//OUTPUT INSERTED.ID  no tiene esa clausula

using var conexion = new SqliteConnection(cadenaConexion);   //hace que se cierre
await conexion.OpenAsync();

var comando = new SqliteCommand(query, conexion);
comando.Parameters.AddWithValue("@DNI", dni);
comando.Parameters.AddWithValue("@Nombre", personaNombre);
comando.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);

await comando.ExecuteNonQueryAsync();

var comandoId = new SqliteCommand("SELECT last_insert_rowid();", conexion);
var newId = (long)await comandoId.ExecuteScalarAsync();

Console.WriteLine($"Id: {newId}");