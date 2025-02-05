using Microsoft.Data.SqlClient;
using System.Data;

var personaId = 2;

var cadenaDeConexion = "workstation id=GuidoAlumnoDB.mssql.somee.com;packet size=4096;user id=guidoagustin_SQLLogin_1;pwd=fmvfrm1hbh;data source=GuidoAlumnoDB.mssql.somee.com;persist security info=False;initial catalog=GuidoAlumnoDB;TrustServerCertificate=True";

var query = "SELECT * FROM Personas WHERE ID=@ID;";

using var conexion = new SqlConnection(cadenaDeConexion);   //hace que se cierre
conexion.Open();

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