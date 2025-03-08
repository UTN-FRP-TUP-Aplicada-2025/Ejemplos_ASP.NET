using Microsoft.Data.SqlClient;


var dni = 27712333;
var personaNombre = "Andrea";
var fechaNacimiento = new DateTime(1990, 10, 10);

var cadenaConexion = "workstation id=Ejemplos_ASP_MVC_DB.mssql.somee.com;packet size=4096;user id=fernando-dev_SQLLogin_1;pwd=bfzixu5w6p;data source=Ejemplos_ASP_MVC_DB.mssql.somee.com;persist security info=False;initial catalog=Ejemplos_ASP_MVC_DB;TrustServerCertificate=True";

var query =
@"insert into Personas (DNI, Nombre, Fecha_Nacimiento) 
  OUTPUT INSERTED.ID 
  VALUES (@DNI,@Nombre,@FechaNacimiento)";

using var conexion = new SqlConnection(cadenaConexion);   //hace que se cierre
await conexion.OpenAsync();

var comando = new SqlCommand(query, conexion);
comando.Parameters.AddWithValue("@DNI", dni);
comando.Parameters.AddWithValue("@Nombre", personaNombre);
comando.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);

var newId = await comando.ExecuteScalarAsync();

Console.WriteLine($"Id: {newId}" );