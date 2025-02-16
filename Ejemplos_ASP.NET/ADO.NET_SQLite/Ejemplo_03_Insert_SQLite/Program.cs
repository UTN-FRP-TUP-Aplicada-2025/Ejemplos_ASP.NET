

using Microsoft.Data.Sqlite;

var dni = 23432333;
var personaNombre = "Marianela";
var fechaNacimiento = new DateTime(1990, 10, 10);

var cadenaConexion = "Data Source=../../../../Db/Personas_db.db";

var query =
@"INSERT INTO Personas (DNI, Nombre, Fecha_Nacimiento) 
VALUES (@DNI,@Nombre,@FechaNacimiento)";

using var conexion = new SqliteConnection(cadenaConexion);
await conexion.OpenAsync();

using var comando = new SqliteCommand(query, conexion);
comando.Parameters.AddWithValue("@DNI", dni);
comando.Parameters.AddWithValue("@Nombre", personaNombre);
comando.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);

var cantidad = await comando.ExecuteNonQueryAsync();

Console.WriteLine($"cantidad de registros insertados: {cantidad}");