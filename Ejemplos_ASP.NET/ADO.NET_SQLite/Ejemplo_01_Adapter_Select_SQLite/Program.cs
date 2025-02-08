
using Microsoft.Data.Sqlite;
using System.Data;

var cadenaconexion = "Data Source=personas_db.db;Version=3;";

var query = "SELECT * FROM PERSONAS";

using var conexion = new SqliteConnection(cadenaconexion);
conexion.Open();

using var comando = new SqliteCommand(query,conexion);
var dt = new DataTable();

//var adaptador = new SqlDataAdapter(comando);
//adaptador.Fill(dt);

//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine($"{dr["id"]};{dr["nombre"]}");
//}