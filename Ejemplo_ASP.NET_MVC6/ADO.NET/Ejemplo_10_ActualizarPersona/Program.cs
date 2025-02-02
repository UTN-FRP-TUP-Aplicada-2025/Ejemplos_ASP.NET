//
using Ej10_ActualizarPersona.Models;
using Ejemplo_10_ActualizarPersona.Utils;
using Microsoft.Data.SqlClient;



var cadenaConexion = ConexionString.Valor;

var nuevo = new PersonaModel
{
    Id = 1,
    Nombre = "Marianela",
    DNI = 33333333,
    FechaNacimiento = new DateTime(1998, 2, 23)
};

#region conexion al servidor
using var conexion = new SqlConnection(ConexionString.Valor);
conexion.Open();
#endregion

#region preparo el comando sql
string sqlQuery =
@"UPDATE Personas SET Dni=@Dni, Nombre=@Nombre, Fecha_Nacimiento=@Fecha_Nacimiento
WHERE Id=@Id";

using var query = new SqlCommand(sqlQuery, conexion);
query.Parameters.AddWithValue("@Dni", nuevo.DNI);
query.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
query.Parameters.AddWithValue("@Fecha_Nacimiento", nuevo.FechaNacimiento);
query.Parameters.AddWithValue("@Id", nuevo.Id);
#endregion

#region ejecuto el comando
int cantidad = query.ExecuteNonQuery();
#endregion 

Console.WriteLine($"registro actualizados: {cantidad}");
Console.WriteLine(nuevo);