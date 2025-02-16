
using Microsoft.Data.SqlClient;


//var cadenaConexion = "Server=localhost;Database=BaseMaxima;Integrated Security=True;TrustServerCertificate=True";
var cadenaConexion = "workstation id=Ejemplos_ASP_MVC_DB.mssql.somee.com;packet size=4096;user id=fernando-dev_SQLLogin_1;pwd=bfzixu5w6p;data source=Ejemplos_ASP_MVC_DB.mssql.somee.com;persist security info=False;initial catalog=Ejemplos_ASP_MVC_DB;TrustServerCertificate=True";

var query =
@"SELECT p.* 
FROM Personas p
WHERE UPPER(p.Nombre) LIKE UPPER(@Nombre) ";//normalizando los nombres

using var conexion = new SqlConnection(cadenaConexion);
await conexion.OpenAsync();

//nombres que contiene 'ma'
using var comando = new SqlCommand(query, conexion);
//comando.Parameters.AddWithValue("@Nombre", "%Ma%");
comando.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar).Value = "%Ma%";


var reader =await comando.ExecuteReaderAsync();

Console.WriteLine($"{"Id",10}|{"DNI",10}|{"Nombre",-30}|{"Fecha",10}");
Console.WriteLine("".PadRight(63,'-'));
while (await reader.ReadAsync())
{
    int id = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0;
    int dni = reader["DNI"] != DBNull.Value ? Convert.ToInt32(reader["DNI"]) : 0;
    string nombre = reader["Nombre"] != DBNull.Value ? Convert.ToString(reader["Nombre"]) : "";
    DateTime? nacimiento = reader["Fecha_Nacimiento"] != DBNull.Value ? Convert.ToDateTime(reader["Fecha_Nacimiento"]) : (DateTime?)null;

    Console.WriteLine($"{id,10}|{dni,10}|{nombre,-30}|{nacimiento,10:dd/MM/yyyy}");
}   
