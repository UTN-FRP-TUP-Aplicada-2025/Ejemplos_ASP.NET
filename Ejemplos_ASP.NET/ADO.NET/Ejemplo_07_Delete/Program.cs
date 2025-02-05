using Microsoft.Data.SqlClient;
using System.Data;

var personaId = 2;

string cadenaConexion = "workstation id=Ejemplos_ASP_MVC_DB.mssql.somee.com;packet size=4096;user id=fernando-dev_SQLLogin_1;pwd=bfzixu5w6p;data source=Ejemplos_ASP_MVC_DB.mssql.somee.com;persist security info=False;initial catalog=Ejemplos_ASP_MVC_DB;TrustServerCertificate=True";

var query = 
@"DELETE Personas 
WHERE ID=@Id;";          //ojo aquí, si la condición elimina a todos

using var conexion = new SqlConnection(cadenaConexion);   //hace que se cierre
conexion.Open();

var comando = new SqlCommand(query, conexion);
comando.Parameters.AddWithValue("@ID", personaId);

int eliminados=comando.ExecuteNonQuery();

Console.WriteLine($"Cantidad de eliminados: {eliminados} registros");
