using Ejemplo_03_Login_Simple.Models;

using Microsoft.Data.SqlClient;

namespace Ejemplo_03_Login_Simple.DALs.MSSDALs;

public class UsuariosMSSDAL : IUsuariosDAL
{
    public List<UsuarioModel> GetAll()
    {
        var lista = new List<UsuarioModel>();

        string sqlQuery =
@"SELECT u.* 
FROM Usuarios u";

        using var conexion = new SqlConnection(ConexionString.Valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);

        var reader = query.ExecuteReader();

        while (reader.Read())
        {
            string? nombre = reader["Nombre"] as string;
            string? clave = reader["Clave"] as string;

            var objeto = new UsuarioModel { Nombre = nombre, Clave = clave };

            lista.Add(objeto);
        }
        return lista;
    }

    public UsuarioModel? GetByKey(string nombre)
    {
        UsuarioModel objeto = null;

        string sqlQuery =
@"SELECT TOP 1 u.* 
FROM Usuarios u
WHERE UPPER(TRIM(u.Nombre)) LIKE UPPER(TRIM(@Nombre))";

        using var conexion = new SqlConnection(ConexionString.Valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Nombre", nombre);

        var reader = query.ExecuteReader();

        if (reader.Read())
        {
            string? nombreBD = reader["Nombre"] as string;
            string? clave = reader["Clave"] as string;

            objeto = new UsuarioModel { Nombre = nombreBD, Clave = clave };
        }
        return objeto;
    }

    public bool Insert(UsuarioModel nuevo)
    {
        string sqlQuery =
@"INSERT Usuarios(Nombre, Clave)
VALUES (@Nombre, @Clave)";

        using var conexion = new SqlConnection(ConexionString.Valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Nombreo", nuevo.Nombre);
        query.Parameters.AddWithValue("@Clave", nuevo.Clave);

        int cantInsertados = Convert.ToInt32(query.ExecuteNonQuery());
        return cantInsertados > 0;
    }

    public bool Update(UsuarioModel actualizar)
    {
        string sqlQuery =
@"UPDATE Usuarios SET Clave=@Clave
WHERE UPPER(TRIM(Nombre)) LIKE UPPER(@Nombre_Usuario)";

        using var conexion = new SqlConnection(ConexionString.Valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Clave", actualizar.Clave);
        query.Parameters.AddWithValue("@Nombre_Usuario", actualizar.Nombre);

        int cantidad = query.ExecuteNonQuery();

        return cantidad > 0;
    }

    public void Delete(string nombre)
    {
        string sqlQuery =
@"DELETE FROM Usuarios
WHERE UPPER(TRIM(Nombre)) LIKE UPPER(@Nombre)";

        using var conexion = new SqlConnection(ConexionString.Valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Nombre", nombre);

        var eliminados = query.ExecuteScalar();
    }

}
