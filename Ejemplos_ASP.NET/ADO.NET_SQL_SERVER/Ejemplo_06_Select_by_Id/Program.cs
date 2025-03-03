using Microsoft.Data.SqlClient;
using System.Data;

var personaId = 2;

var cadenaConexion = "workstation id=Ejemplos_ASP_MVC_DB.mssql.somee.com;packet size=4096;user id=fernando-dev_SQLLogin_1;pwd=bfzixu5w6p;data source=Ejemplos_ASP_MVC_DB.mssql.somee.com;persist security info=False;initial catalog=Ejemplos_ASP_MVC_DB;TrustServerCertificate=True";

var query = 
@"SELECT * 
FROM Personas 
WHERE ID=@ID;";

using var conexion = new SqlConnection(cadenaConexion);   //hace que se cierre
await conexion.OpenAsync();

var comando = new SqlCommand(query, conexion);
comando.Parameters.AddWithValue("@ID", personaId);

//lleva adaptador por leer con select
var dt = new DataTable(query);
var adaptador = new SqlDataAdapter(comando);
adaptador.Fill(dt);


foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine($"{dr["id"]};{dr["nombre"]}");
}