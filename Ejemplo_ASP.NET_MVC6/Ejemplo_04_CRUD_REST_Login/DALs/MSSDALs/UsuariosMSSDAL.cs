using Ejemplo_04_CRUD_REST_Login.DALs.MSSDALs;
using Ejemplo_04_CRUD_REST_Login.Models;

using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace Ejemplo_04_CRUD_REST_Login.DALs.MSSDAO;

public class UsuariosMSSDAL : IUsuariosDAL
{
    public List<UsuarioModel> GetAll()
    {
        var lista = new List<UsuarioModel>();

        string sqlQuery =
@"SELECT u.* 
FROM Usuarios u";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);

        var reader = query.ExecuteReader();

        while (reader.Read())
        {
            int id = Convert.ToInt32(reader["Id"]);
            string? uuid = reader["UUID"] as string;
            string? name = reader["Nombre"] as string;
            string? password = reader["Clave"] as string;

            var objeto = new UsuarioModel { Id = id, UUID = uuid, Nombre = name, Clave = password };

            lista.Add(objeto);
        }
        return lista;
    }

    public UsuarioModel? GetById(int id)
    {
        UsuarioModel objeto = null;

        string sqlQuery =
@"SELECT TOP 1 u.* 
FROM usuarios u 
WHERE u.Id=@Id";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Id", id);

        var reader = query.ExecuteReader();

        if (reader.Read())
        {
            int idG = Convert.ToInt32(reader["Id"]);
            string? uuid = reader["UUID"] as string;
            string? name = reader["Nombre"] as string;
            string? password = reader["Clave"] as string;

            objeto = new UsuarioModel { Id = idG, UUID = uuid, Nombre = name, Clave = password };
        }

        return objeto;
    }

    public UsuarioModel? GetByUUID(string uuid)
    {
        UsuarioModel objeto = null;

        string sqlQuery =
@"SELECT TOP 1 u.* 
FROM Usuarios u
WHERE u.UUID=@UUID";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@UUID", uuid);

        var reader = query.ExecuteReader();

        if (reader.Read())
        {
            int id = Convert.ToInt32(reader["Id"]);
            string? uuidBD = reader["UUID"] as string;
            string? name = reader["Nombre"] as string;
            string? password = reader["Clave"] as string;

            objeto = new UsuarioModel { Id = id, UUID = uuidBD, Nombre = name, Clave = password };
        }

        return objeto;
    }

    public UsuarioModel? GetByNombre(string nombre)
    {
        UsuarioModel objeto = null;

        string sqlQuery =
@"SELECT TOP 1 u.* 
FROM Usuarios u
WHERE UPPER(TRIM(u.Nombre)) LIKE UPPER(TRIM(@Nombre))";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Nombre", nombre);

        var reader = query.ExecuteReader();

        if (reader.Read())
        {
            int id = Convert.ToInt32(reader["Id"]);
            string? uuid = reader["UUID"] as string;
            string? nombreBD = reader["Nombre"] as string;
            string? password = reader["Clave"] as string;

            objeto = new UsuarioModel { Id = id, UUID = uuid, Nombre = nombreBD, Clave = password };
        }
        return objeto;
    }

    public bool Insert(UsuarioModel nuevo)
    {
        string sqlQuery =
@"INSERT Usuarios(UUID, Nombre, Clave)
OUTPUT INSERTED.ID 
VALUES (@UUID, @Nombre, @Clave)";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@UUID", nuevo.UUID);
        query.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
        query.Parameters.AddWithValue("@Clave", HashPassword(nuevo.Clave));

        nuevo.Id = Convert.ToInt32(query.ExecuteScalar());
        return nuevo.Id > 0;
    }

    public bool Update(UsuarioModel actualizar)
    {
        string sqlQuery =
@"UPDATE Usuarios SET UUID=@UUID, Nombre=@Nombre, Clave=@Clave
WHERE Id=@Id";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@UUID", actualizar.UUID);
        query.Parameters.AddWithValue("@Nombre", actualizar.Nombre);
        query.Parameters.AddWithValue("@Clave", actualizar.Clave);
        query.Parameters.AddWithValue("@Id", actualizar.Id);

        int cantidad = query.ExecuteNonQuery();

        return cantidad > 0;
    }

    public void Delete(int id)
    {
        string sqlQuery =
@"DELETE FROM Usuarios
WHERE Id=@Id";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Id", id);

        var eliminados = query.ExecuteScalar();
    }

    public string HashPassword(string input)
    {
        if (string.IsNullOrEmpty(input))
            throw new ArgumentNullException(nameof(input), "Input string cannot be null or empty");

        using var sha256 = SHA256.Create();

        byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        byte[] hashBytes = sha256.ComputeHash(inputBytes);

        return BitConverter.ToString(hashBytes).Replace("-", "").ToUpper();

    }
}
