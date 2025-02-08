
DECLARE @Nombre_Usuario NVARCHAR(50)='Eduardo';

BEGIN TRANSACTION;

BEGIN TRY
    
    DELETE FROM Usuarios_Roles
    WHERE UPPER(Nombre_Usuario) = UPPER(@Nombre_Usuario);

    DELETE FROM Usuarios
    WHERE UPPER(Nombre) = UPPER(@Nombre_Usuario);

    COMMIT TRANSACTION;
    PRINT 'Transacci�n completada con �xito.';

END TRY
BEGIN CATCH

    ROLLBACK TRANSACTION;
    PRINT 'Error detectado. Transacci�n deshecha.';

    THROW;
END CATCH;