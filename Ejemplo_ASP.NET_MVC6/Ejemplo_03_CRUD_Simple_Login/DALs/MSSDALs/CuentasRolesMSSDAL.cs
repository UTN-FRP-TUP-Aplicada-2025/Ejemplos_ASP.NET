using Ejemplo_03_CRUD_Simple_Login.DALs.MSSDALs;
using Ejemplo_03_CRUD_Simple_Login.Models;

using Microsoft.Data.SqlClient;

namespace Ejemplo_03_CRUD_Simple_Login.DALs.MSSDAO;

public class CuentasRolesMSSDAL : ICuentasRolesDAL
{
    
    public List<CuentaRolModel> GetAll()
    {
        var lista = new List<CuentaRolModel>();
               
        string sqlQuery = 
@"SELECT * 
FROM CuentasRoles";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);

        var reader = query.ExecuteReader();

        while (reader.Read())
        {
            int idCuenta = Convert.ToInt32(reader["Id_Cuenta"]);
            int idRol = Convert.ToInt32(reader["Id_Rol"]);

            var objeto = new CuentaRolModel { IdCuenta=idCuenta, IdRol=idRol };

            lista.Add(objeto);
        }
        return lista;
    }

    public CuentaRolModel? GetById(int id)
    {
        CuentaRolModel? objeto = null;

        string sqlQuery = 
@"SELECT TOP 1 * 
FROM Cuentas_Roles cr
WHERE cr.Id=@Id";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Id", id);

        var reader = query.ExecuteReader();
        
        if (reader.Read())
        {
            int idCuenta = Convert.ToInt32(reader["Id_Rol"]);
            int idRol = Convert.ToInt32(reader["Id_Cuenta"]);

            objeto = new CuentaRolModel { IdCuenta = idCuenta, IdRol = idRol };
        }
        return objeto;
    }

    public bool Insert(CuentaRolModel nuevo)
    {
        string sqlQuery =
@"INSERT Cuentas_Roles(Id_Cuenta, Id_Rol)
VALUES (@Id_Cuenta, @Id_Rol)"; 

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Id_Cuenta", nuevo.IdCuenta);
        query.Parameters.AddWithValue("@Id_Rol", nuevo.IdRol);

        int insertados= query.ExecuteNonQuery();
        return insertados > 0;
    }

    public bool Update(CuentaRolModel actualizar)
    {
        string sqlQuery =
@"UPDATE Cuentas_Roles SET Id_Rol=@Id_Rol
WHERE Id_Cuenta=@Id_Cuenta";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Id_Cuenta", actualizar.IdCuenta);
        query.Parameters.AddWithValue("@Id_Rol", actualizar.IdRol);

        int cantidad=query.ExecuteNonQuery();

        return cantidad > 0;
    }

    public void Delete(int id)
    {
        string sqlQuery =
@"DELETE FROM Cuentas_Roles
WHERE Id_Cuenta=@Id_Cuenta";

        using var conexion = new SqlConnection(ConexionString.valor);
        conexion.Open();

        using var query = new SqlCommand(sqlQuery, conexion);
        query.Parameters.AddWithValue("@Id_Cuenta", id);

        var eliminados = query.ExecuteScalar();
    }

}
