--DECLARE @Password NVARCHAR(255) = '123';
--DECLARE @PasswordHash VARBINARY(64)= HASHBYTES('SHA2_256', CONVERT(VARCHAR(255), @Password, 2));
--SELECT @PasswordHash 
--DECLARE @Base64Hash NVARCHAR(MAX);
--SET @Base64Hash = CAST('' AS XML).value('xs:base64Binary(sql:variable("@PasswordHash"))', 'NVARCHAR(MAX)');
--SELECT @Base64Hash;

--DECLARE @uuid UNIQUEIDENTIFIER = NEWID();

--INSERT INTO Usuarios(UUID, Nombre, Clave)
--VALUES(@uuid, 'Admin', CONVERT(NVARCHAR(200), @PasswordHash,2))
