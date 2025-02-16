using Microsoft.Data.SqlClient;

var personaId = 3;

string cadenaConexion = "workstation id=Ejemplos_ASP_MVC_DB.mssql.somee.com;packet size=4096;user id=fernando-dev_SQLLogin_1;pwd=bfzixu5w6p;data source=Ejemplos_ASP_MVC_DB.mssql.somee.com;persist security info=False;initial catalog=Ejemplos_ASP_MVC_DB;TrustServerCertificate=True";

var query = 
@"DELETE Personas 
WHERE ID=@Id;";          //ojo aquí, si la condición elimina a todos

using var conexion = new SqlConnection(cadenaConexion);   //hace que se cierre
await conexion.OpenAsync();

var comando = new SqlCommand(query, conexion);
comando.Parameters.AddWithValue("@ID", personaId);

int eliminados=await comando.ExecuteNonQueryAsync();

Console.WriteLine($"Cantidad de eliminados: {eliminados} registros");
