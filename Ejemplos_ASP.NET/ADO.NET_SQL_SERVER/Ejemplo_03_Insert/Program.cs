
using Microsoft.Data.SqlClient;

var dni = 23432333;
var personaNombre = "Marianela";
var fechaNacimiento = new DateTime(1990, 10, 10);

//var cadenaconexion = "Server=localhost;Database=BaseMaxima;Integrated Security=True;TrustServerCertificate=True";
var cadenaConexion = "workstation id=Ejemplos_ASP_MVC_DB.mssql.somee.com;packet size=4096;user id=fernando-dev_SQLLogin_1;pwd=bfzixu5w6p;data source=Ejemplos_ASP_MVC_DB.mssql.somee.com;persist security info=False;initial catalog=Ejemplos_ASP_MVC_DB;TrustServerCertificate=True";

var query =
@"INSERT INTO Personas (DNI, Nombre, Fecha_Nacimiento) 
VALUES (@DNI,@Nombre,@FechaNacimiento)";

using var conexion = new SqlConnection(cadenaConexion);
await conexion.OpenAsync();

using var comando = new SqlCommand(query, conexion);
comando.Parameters.AddWithValue("@DNI", dni);
comando.Parameters.AddWithValue("@Nombre", personaNombre);
comando.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);

var cantidad = await comando.ExecuteNonQueryAsync();

Console.WriteLine($"cantidad de registros insertados: {cantidad}");