
using Microsoft.Data.SqlClient;
using System.Data;

var personaNombre = "Marianela";
var cadenaconexion = "Server=localhost;Database=BaseMaxima;Integrated Security=True;TrustServerCertificate=True";

var query = "INSERT INTO Personas (Nombre) Values ('@Nombre1')";

using var conexion = new SqlConnection(cadenaconexion);
conexion.Open();

using var comando = new SqlCommand(query, conexion);
comando.Parameters.AddWithValue("@Nombre1", personaNombre);

var cantidad = comando.ExecuteNonQuery();

Console.WriteLine(cantidad);