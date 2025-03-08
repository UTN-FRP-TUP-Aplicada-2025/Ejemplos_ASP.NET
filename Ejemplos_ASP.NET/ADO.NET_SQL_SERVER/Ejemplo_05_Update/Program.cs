using Microsoft.Data.SqlClient;
using System.Data;

var personaNombre = "Carlos";
var personaId = 1;

var cadenaConexion = "workstation id=Ejemplos_ASP_MVC_DB.mssql.somee.com;packet size=4096;user id=fernando-dev_SQLLogin_1;pwd=bfzixu5w6p;data source=Ejemplos_ASP_MVC_DB.mssql.somee.com;persist security info=False;initial catalog=Ejemplos_ASP_MVC_DB;TrustServerCertificate=True";

var query = "UPDATE Personas SET Nombre = @Nombre WHERE ID = @ID";

using var conexion = new SqlConnection(cadenaConexion);   //hace que se cierre
await conexion.OpenAsync();

var comando = new SqlCommand(query, conexion);
comando.Parameters.AddWithValue("@Nombre", personaNombre);
comando.Parameters.AddWithValue("@ID", personaId);

var cantidad = await comando.ExecuteNonQueryAsync();

Console.WriteLine($"cantidad de registros actualizados: {cantidad}");