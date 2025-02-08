using Ejemplo_08_Consulta_Personas.Models;
using Ejemplo_08_Consulta_Personas.Utils;
using Microsoft.Data.SqlClient;
using System.Data;

PersonaModel ReadAsPersona(DataRow dr)
{
    int id = dr["Id"] != DBNull.Value ? Convert.ToInt32(dr["Id"]) : 0;
    int dni = dr["DNI"] != DBNull.Value ? Convert.ToInt32(dr["DNI"]) : 0;
    string nombre = dr["Nombre"] != DBNull.Value ? Convert.ToString(dr["Nombre"]) : "";
    DateTime? nacimiento = dr["Fecha_Nacimiento"] != DBNull.Value ? Convert.ToDateTime(dr["Fecha_Nacimiento"]) : (DateTime?)null;

    var objeto = new PersonaModel { Id = id, DNI = dni, Nombre = nombre, FechaNacimiento = nacimiento };

    return objeto;
}

List<PersonaModel> ReadAsPersonas(DataTable dt)
{
    List<PersonaModel> personas = new List<PersonaModel>();

    foreach (DataRow dr in dt.Rows)
    {
        var p = ReadAsPersona(dr);
        personas.Add(p);
    }

    return personas;
}

var cadenaconexion = ConexionString.Valor;

var query = 
@"SELECT p.* 
FROM Personas p";

using var conexion = new SqlConnection(cadenaconexion);
await conexion.OpenAsync();

using var comando = new SqlCommand(query, conexion);
var dt = new DataTable();

var adaptador = new SqlDataAdapter(comando);
adaptador.Fill(dt);

var personas = ReadAsPersonas(dt);

foreach (var p in personas)
{ 
    Console.WriteLine(p);    
}