using Ejemplo_03_CRUD_Simple_Login.DALs.MSSDALs;
using Ejemplo_03_CRUD_Simple_Login.Models;
using Microsoft.Data.SqlClient;

namespace Ejemplo_03_CRUD_Simple_Login.DALs.MSSDAO;

public class CuentasMSSDAL : ICuentasDAL
{
    public List<CuentaModel> GetAll()
    {
        var lista = new List<CuentaModel>();
               
        string sqlQuery = 
@"SELECT * 
FROM Cuentas";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);

        var reader = query.ExecuteReader();

        while (reader.Read())
        {
            int id = Convert.ToInt32(reader["Id"]);
            string? uuid = reader["UUID"] as string;
            string? name = reader["Nombre"] as string;
            string? password= reader["Clave"] as string;

            var objeto = new CuentaModel {Id=id, UUID = uuid, Nombre =name, Clave=password };

            lista.Add(objeto);
        }
        return lista;
    }

    public CuentaModel? GetById(int id)
    {
        CuentaModel objeto = null;

        string sqlQuery = 
@"SELECT TOP 1 * 
FROM Cuentas p
WHERE p.Id=@Id";

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

            objeto = new CuentaModel { Id = idG, UUID = uuid, Nombre = name, Clave = password };
        }

        return objeto;
    }

    public CuentaModel? GetByUUID(string uuid)
    {
        CuentaModel objeto = null;

        string sqlQuery =
@"SELECT TOP 1 * 
FROM Cuentas p
WHERE p.UUID=@UUID";

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

            objeto = new CuentaModel { Id = id, UUID=uuidBD, Nombre = name, Clave = password };
        }

        return objeto;
    }

    public CuentaModel? GetByNombre(string nombre)
    {
        CuentaModel objeto = null;

        string sqlQuery =
@"SELECT TOP 1 c.* 
FROM Cuentas c
WHERE UPPER(TRIM(c.Nombre)) LIKE UPPER(TRIM(@Nombre))";

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

            objeto = new CuentaModel { Id = id, UUID = uuid, Nombre = nombreBD, Clave = password };
        }
        return objeto;
    }

    public bool Insert(CuentaModel nuevo)
    {
        string sqlQuery =
@"INSERT Cuentas(UUID, Nombre, Clave)
OUTPUT INSERTED.ID 
VALUES (@UUID, @Nombre, @Clave)"; 

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@UUID", nuevo.UUID);
        query.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
        query.Parameters.AddWithValue("@Clave", nuevo.Clave);

        nuevo.Id = Convert.ToInt32( query.ExecuteScalar() );
        return nuevo.Id > 0;
    }

    public bool Update(CuentaModel actualizar)
    {
        string sqlQuery =
@"UPDATE Cuentas SET UUID=@UUID, Nombre=@Nombre, Clave=@Clave
WHERE Id=@Id";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@UUID", actualizar.UUID);
        query.Parameters.AddWithValue("@Nombre", actualizar.Nombre);
        query.Parameters.AddWithValue("@Clave", actualizar.Clave);
        query.Parameters.AddWithValue("@Id", actualizar.Id);

        int cantidad=query.ExecuteNonQuery();

        return cantidad > 0;
    }

    public void Delete(int id)
    {
        string sqlQuery =
@"DELETE FROM Cuentas
WHERE Id=@Id";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Id", id);

        var eliminados = query.ExecuteScalar();
    }
}
