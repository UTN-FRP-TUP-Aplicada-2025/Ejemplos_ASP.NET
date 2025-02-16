using Microsoft.Data.SqlClient;
using System.Data.Common;


/*Resumen:
 
 aquí trata de eliminar una registro que tiene una relación de uno a muchos - al eliminar el contenedor 
 eliminamos en cascada a los muchos.

En t-sql sería:
 
DECLARE @Nombre_Usuario NVARCHAR(50)='Eduardo';

BEGIN TRANSACTION;

BEGIN TRY
    
    DELETE FROM Usuarios_Roles
    WHERE UPPER(Nombre_Usuario) = UPPER(@Nombre_Usuario);

    DELETE FROM Usuarios
    WHERE UPPER(Nombre) = UPPER(@Nombre_Usuario);

    COMMIT TRANSACTION;
    PRINT 'Transacción completada con éxito.';

END TRY
BEGIN CATCH

    ROLLBACK TRANSACTION;
    PRINT 'Error detectado. Transacción deshecha.';

    THROW;
END CATCH;
 
 
 */

var usuario = "eduardo";

string cadenaConexion = "workstation id=Ejemplos_ASP_MVC_DB.mssql.somee.com;packet size=4096;user id=fernando-dev_SQLLogin_1;pwd=bfzixu5w6p;data source=Ejemplos_ASP_MVC_DB.mssql.somee.com;persist security info=False;initial catalog=Ejemplos_ASP_MVC_DB;TrustServerCertificate=True";

#region consultas sql: datos del usuario eduardo
var queryDeleteUsuarios =
@"DELETE Usuarios
WHERE UPPER(Nombre)=UPPER(@Nombre_Usuario);";

var queryDeleteUsuarios_Roles =
@"DELETE Usuarios_Roles
WHERE UPPER(Nombre_Usuario)=UPPER(@Nombre_Usuario);";
#endregion

using var conexion = new SqlConnection(cadenaConexion);   //hace que se cierre
await conexion.OpenAsync();

SqlTransaction transaction = conexion.BeginTransaction();
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

    //caso 2
    /*
    comando.CommandText = queryDeleteUsuarios;
    comando.Parameters.AddWithValue("@Nombre_Usuario", usuario);
    int usuariosEliminados = comando.ExecuteNonQuery();
    Console.WriteLine($"Cantidad de eliminados: {usuariosEliminados} registros");

    comando.CommandText = queryDeleteUsuarios_Roles;
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

