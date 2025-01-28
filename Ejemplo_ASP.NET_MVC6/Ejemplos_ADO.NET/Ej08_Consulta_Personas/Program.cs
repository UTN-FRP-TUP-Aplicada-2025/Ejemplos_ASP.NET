

using Ej08_Consulta_Personas.Models;

#region consulta sql
using Microsoft.Data.SqlClient;
using System.Data;

var cadenaconexion = "workstation id=GuidoAlumnoDB.mssql.somee.com;packet size=4096;user id=guidoagustin_SQLLogin_1;pwd=fmvfrm1h5h;data source=GuidoAlumnoDB.mssql.somee.com;persist security info=False;initial catalog=GuidoAlumnoDB;TrustServerCertificate=True";


var query = "SELECT * FROM PERSONAS";

using var conexion = new SqlConnection(cadenaconexion);
conexion.Open();

using var comando = new SqlCommand(query, conexion);
var dt = new DataTable();

var adaptador = new SqlDataAdapter(comando);
adaptador.Fill(dt);
#endregion

#region es convertir lo relacional en objetos
List<Persona> personas = new List<Persona>();

foreach (DataRow dr in dt.Rows)
{
    var nuevo = new Persona()
    {
        Id = Convert.ToInt32(dr["id"]),
        Nombre = dr["nombre"] as string
    };
    personas.Add(nuevo);
}
#endregion

//para prueba
foreach (var p in personas)
{ 
    Console.WriteLine(p);    
}