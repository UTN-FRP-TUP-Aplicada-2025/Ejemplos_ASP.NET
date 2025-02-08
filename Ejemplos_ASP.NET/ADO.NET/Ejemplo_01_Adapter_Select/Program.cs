
using Microsoft.Data.SqlClient;
using System.Data;

public void CrearBase()
{
    string connectionString = $"Data Source=mydatabase.db;Version=3;";

    using (var connection = new SQLiteConnection(connectionString))
    {
        connection.Open();

        // Crear una tabla
        string createTableQuery = "CREATE TABLE IF NOT EXISTS Person " +
                                 "(Id INTEGER PRIMARY KEY, Name TEXT, Age INT)";
        using (var createTableCommand = new SQLiteCommand(createTableQuery,
                                           connection))
        {
            createTableCommand.ExecuteNonQuery();
        }

        // Insertar datos
        string insertDataQuery = "INSERT INTO Person (Name, Age)" +
                          " VALUES (@Name, @Age)";
        using (var insertDataCommand = new SQLiteCommand(insertDataQuery,
                                          connection))
        {
            insertDataCommand.Parameters.AddWithValue("@Name", "Ejemplo");
            insertDataCommand.Parameters.AddWithValue("@Age", 30);
            insertDataCommand.ExecuteNonQuery();
        }

        // Consultar datos
        string selectDataQuery = "SELECT * FROM Person";
        using (var selectDataCommand = new SQLiteCommand(selectDataQuery,
                                  connection))
        {
            using (var reader = selectDataCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    string name = reader["Name"].ToString();
                    int age = Convert.ToInt32(reader["Age"]);
                    Console.WriteLine($"ID: {id}, Nombre: {name}, Edad: {age}");
                }
            }
        }
        Console.ReadKey();
    }
}



var cadenaconexion = "workstation id=MaximaAlumnosBD.mssql.somee.com;packet size=4096;user id=Maxima1428_SQLLogin_1;pwd=si8gmykxbl;data source=MaximaAlumnosBD.mssql.somee.com;persist security info=False;initial catalog=MaximaAlumnosBD;TrustServerCertificate=True";
//var cadenaconexion = "Server=localhost;Database=BaseMaxima;Integrated Security=True;TrustServerCertificate=True";

var query = "SELECT * FROM PERSONAS";

using var conexion = new SqlConnection(cadenaconexion);
conexion.Open();

using var comando = new SqlCommand(query, conexion);
var dt = new DataTable();

var adaptador = new SqlDataAdapter(comando);
adaptador.Fill(dt);

foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine($"{dr["id"]};{dr["nombre"]}");
}