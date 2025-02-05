using Microsoft.Data.SqlClient;
using System.Data.Common;


//Lazy idea aquí es elimina una relacion de uno a muchos - al eliminar el contenedor 
//eliminamos en cascada los muchos

var usuario = "eduardo";

string cadenaConexion = "workstation id=Ejemplos_ASP_MVC_DB.mssql.somee.com;packet size=4096;user id=fernando-dev_SQLLogin_1;pwd=bfzixu5w6p;data source=Ejemplos_ASP_MVC_DB.mssql.somee.com;persist security info=False;initial catalog=Ejemplos_ASP_MVC_DB;TrustServerCertificate=True";

var queryDeleteUsuarios =
@"DELETE Usuarios
WHERE UPPER(Nombre)=UPPER(@Nombre_Usuario);";

var queryDeleteUsuarios_Roles =
@"DELETE Usuarios_Roles
WHERE UPPER(Nombre_Usuario)=UPPER(@Nombre_Usuario);";



using var conexion = new SqlConnection(cadenaConexion);   //hace que se cierre
await conexion.OpenAsync();

Microsoft.Data.SqlClient.SqlTransaction transaction = conexion.BeginTransaction();
try
{
    var comando = conexion.CreateCommand();
    comando.Transaction = transaction;

    comando.CommandText = queryDeleteUsuarios_Roles;
    comando.Parameters.AddWithValue("@Nombre_Usuario", usuario);
    int relacionesARolesEliminadas = comando.ExecuteNonQuery();
    Console.WriteLine($"Cantidad de eliminados: {relacionesARolesEliminadas} registros");

    comando.CommandText = queryDeleteUsuarios;
    int usuariosEliminados = comando.ExecuteNonQuery();
    Console.WriteLine($"Cantidad de eliminados: {usuariosEliminados} registros");

    transaction.Commit();
    Console.WriteLine("Transacción completada exitosamente.");


    /*
    comando.CommandText = queryDeleteUsuarios;
    comando.Parameters.AddWithValue("@Nombre_Usuario", usuario);
    int usuariosEliminados = comando.ExecuteNonQuery();
    Console.WriteLine($"Cantidad de eliminados: {usuariosEliminados} registros");

    comando.CommandText = queryDeleteUsuarios_Roles;
    comando.Parameters.AddWithValue("@Nombre_Usuario", usuario);
    int relacionesARolesEliminadas = comando.ExecuteNonQuery();
    Console.WriteLine($"Cantidad de eliminados: {relacionesARolesEliminadas} registros");

    transaction.Commit();
    Console.WriteLine("Transacción completada exitosamente.");
    */
    /*
     * Transacción fallida. Todos los cambios fueron revertidos.
The DELETE statement conflicted with the REFERENCE constraint "FK_Usuarios_Roles_Usuarios". The conflict occurred in database "Ejemplos_ASP_MVC_DB", table "dbo.Usuarios_Roles", column 'Nombre_Usuario'.
The statement has been terminated.
     */

}
catch (Exception ex)
{
    transaction.Rollback();
    Console.WriteLine("Transacción fallida. Todos los cambios fueron revertidos.");
    Console.WriteLine(ex.Message);
}

