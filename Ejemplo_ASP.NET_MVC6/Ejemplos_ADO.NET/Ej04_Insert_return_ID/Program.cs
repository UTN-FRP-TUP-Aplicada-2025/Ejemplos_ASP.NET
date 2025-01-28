using Microsoft.Data.SqlClient;
using System.Data;

var personaNombre = "Marianela";

var cadenaDeConexion = "workstation id=GuidoAlumnoDB.mssql.somee.com;packet size=4096;user id=guidoagustin_SQLLogin_1;pwd=fmvfrm1hbh;data source=GuidoAlumnoDB.mssql.somee.com;persist security info=False;initial catalog=GuidoAlumnoDB;TrustServerCertificate=True";

var query =
@"insert into Personas (Nombre) 
  OUTPUT INSERTED.ID 
  values (@Nombre1)";

using var conexion = new SqlConnection(cadenaDeConexion);   //hace que se cierre
conexion.Open();

var comando = new SqlCommand(query, conexion);
comando.Parameters.AddWithValue("@Nombre1", personaNombre);

var newId = comando.ExecuteScalar();

Console.WriteLine(newId);