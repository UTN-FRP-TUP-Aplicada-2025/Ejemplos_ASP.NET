

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

using Microsoft.Data.Sqlite;

var usuario = "eduardo";

var cadenaConexion = "Data Source=../../../../Db/Personas_db.db";

var queryDeleteUsuarios =
@"DELETE FROM Usuarios
WHERE UPPER(Nombre)=UPPER(@Nombre_Usuario);";

var queryDeleteUsuarios_Roles =
@"DELETE FROM Usuarios_Roles
WHERE UPPER(Nombre_Usuario)=UPPER(@Nombre_Usuario)";


using var conexion = new SqliteConnection(cadenaConexion);   //hace que se cierre
await conexion.OpenAsync();

SqliteTransaction transaction = conexion.BeginTransaction();
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

}
catch (Exception ex)
{
    transaction.Rollback();
    Console.WriteLine("Transacción fallida. Todos los cambios fueron revertidos.");
    Console.WriteLine(ex.Message);
}

