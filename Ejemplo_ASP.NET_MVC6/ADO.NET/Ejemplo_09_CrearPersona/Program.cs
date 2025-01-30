using Ejemplo_09_CrearPersona.Models;
using Ejemplo_09_CrearPersona.Utils;

using Microsoft.Data.SqlClient;


var cadenaConexion = ConexionString.Valor;

var nuevo = new PersonaModel
{
    Nombre = "Marianela",
    DNI = 32343242,
    FechaNacimiento = new DateTime(1998,2,23)
};

#region conexion al servidor
using var conexion = new SqlConnection(ConexionString.Valor);
conexion.Open();
#endregion

#region preparo el comando sql
string sqlQuery =
@"INSERT Personas(Dni, Nombre, Fecha_Nacimiento)
OUTPUT INSERTED.ID 
VALUES (@Dni, @Nombre, @Fecha_Nacimiento)";

using var query = new SqlCommand(sqlQuery, conexion);
query.Parameters.AddWithValue("@Dni", nuevo.DNI);
query.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
query.Parameters.AddWithValue("@Fecha_Nacimiento", nuevo.FechaNacimiento);
#endregion

#region ejecuto el comando
var respuesta = query.ExecuteScalar();
nuevo.Id = Convert.ToInt32(respuesta);
#endregion 

Console.WriteLine(nuevo);