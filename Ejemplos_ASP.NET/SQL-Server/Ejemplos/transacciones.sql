
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