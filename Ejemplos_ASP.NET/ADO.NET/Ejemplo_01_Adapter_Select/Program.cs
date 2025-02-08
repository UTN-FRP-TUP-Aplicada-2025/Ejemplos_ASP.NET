
using Microsoft.Data.SqlClient;
using System.Data;

var cadenaconexion = "workstation id=MaximaAlumnosBD.mssql.somee.com;packet size=4096;user id=Maxima1428_SQLLogin_1;pwd=si8gmykxbl;data source=MaximaAlumnosBD.mssql.somee.com;persist security info=False;initial catalog=MaximaAlumnosBD;TrustServerCertificate=True";
//var cadenaconexion = "Server=localhost;Database=BaseMaxima;Integrated Security=True;TrustServerCertificate=True";

var query = "SELECT * FROM PERSONAS";

using var conexion = new SqlConnection(cadenaconexion);
conexion.Open();

using var comando = new SqlCommand(query, conexion);
var dt = new DataTable();

var adaptador = new SqlDataAdapter(comando);
adaptador.Fill(dt);

foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine($"{dr["id"]};{dr["nombre"]}");
}