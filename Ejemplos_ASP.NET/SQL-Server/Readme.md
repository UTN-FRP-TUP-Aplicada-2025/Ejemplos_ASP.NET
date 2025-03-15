

# Cadenas de conexión
"workstation id=Ejemplos_ASP_MVC_DB.mssql.somee.com;packet size=4096;user id=fernando-dev_SQLLogin_1;pwd=bfzixu5w6p;data source=Ejemplos_ASP_MVC_DB.mssql.somee.com;persist security info=False;initial catalog=Ejemplos_ASP_MVC_DB;TrustServerCertificate=True"

"Integrated Security=true; Initial Catalog=Ejemplo_03_Login_Simple_DB;Server=TSP;TrustServerCertificate=true;";


--DECLARE @Password NVARCHAR(255) = '123';
--DECLARE @PasswordHash VARBINARY(64)= HASHBYTES('SHA2_256', CONVERT(VARCHAR(255), @Password, 2));
--SELECT @PasswordHash 
--DECLARE @Base64Hash NVARCHAR(MAX);
--SET @Base64Hash = CAST('' AS XML).value('xs:base64Binary(sql:variable("@PasswordHash"))', 'NVARCHAR(MAX)');
--SELECT @Base64Hash;

--DECLARE @uuid UNIQUEIDENTIFIER = NEWID();

--INSERT INTO Usuarios(UUID, Nombre, Clave)
--VALUES(@uuid, 'Admin', CONVERT(NVARCHAR(200), @PasswordHash,2))
