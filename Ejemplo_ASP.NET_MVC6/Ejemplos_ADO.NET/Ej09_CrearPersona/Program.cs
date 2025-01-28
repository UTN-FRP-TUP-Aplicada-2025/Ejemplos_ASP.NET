using Ej07_Consulta_Personas.Models;
using Microsoft.Data.SqlClient;
using System.Data;

void CrearNuevaPersona(Persona nueva)
{
    var cadenaConexion = "workstation id=GuidoAlumnoDB.mssql.somee.com;packet size=4096;user id=guidoagustin_SQLLogin_1;pwd=fmvfrm1h5h;data source=GuidoAlumnoDB.mssql.somee.com;persist security info=False;initial catalog=GuidoAlumnoDB;TrustServerCertificate=True";

    var query =
    @"insert into Personas (Nombre) 
      OUTPUT INSERTED.ID 
      values (@Nombre)";

    using var conexion = new SqlConnection(cadenaConexion);   //hace que se cierre
    conexion.Open();

    var comando = new SqlCommand(query, conexion);
    comando.Parameters.AddWithValue("@Nombre", nueva.Nombre);

    var newId = comando.ExecuteScalar();

    Console.WriteLine(newId);
}


//ejemplo de uso

var nueva = new Persona { 
    Nombre="Marianela",
};

CrearNuevaPersona(nueva);

Console.WriteLine(nueva);