
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System.Data;

var cadenaConexion = "workstation id=Ejemplos_ASP_MVC_DB.mssql.somee.com;packet size=4096;user id=fernando-dev_SQLLogin_1;pwd=bfzixu5w6p;data source=Ejemplos_ASP_MVC_DB.mssql.somee.com;persist security info=False;initial catalog=Ejemplos_ASP_MVC_DB;TrustServerCertificate=True";
//var cadenaConexion = "Server=localhost;Database=BaseMaxima;Integrated Security=True;TrustServerCertificate=True";

var query = 
@"SELECT * 
FROM PERSONAS";

using var conexion = new SqlConnection(cadenaConexion);
await conexion.OpenAsync();

using var comando = new SqlCommand(query, conexion);
var dt = new DataTable();

var adaptador = new SqlDataAdapter(comando);
adaptador.Fill(dt);

foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine($"{dr["id"]};{dr["nombre"]}");
}