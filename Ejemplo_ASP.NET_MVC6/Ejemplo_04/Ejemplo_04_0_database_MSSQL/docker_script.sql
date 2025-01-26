
--cambio a master porque si esta abierta no la va a poder eliminar
USE MASTER

GO

DROP DATABASE IF EXISTS Ejemplo_04_0_Roles_Login_DB

GO

CREATE DATABASE  Ejemplo_04_0_Roles_Login_DB

GO

USE Ejemplo_04_0_Roles_Login_DB

GO

CREATE TABLE Usuarios
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	UUID  NVARCHAR(200) NOT NULL UNIQUE,
	Nombre NVARCHAR(50) NOT NULL UNIQUE,
	Clave NVARCHAR(200) NOT NULL,
);

GO

CREATE TABLE Roles
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(50) NOT NULL UNIQUE,
);

GO

CREATE TABLE  Usuarios_Roles
(
	Id_Usuario INT NOT NULL,
	Id_Rol INT NOT NULL,
	CONSTRAINT UQ_Usuarios_Roles UNIQUE (Id_Usuario, Id_Rol)
);

GO

CREATE TABLE Personas
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	DNI INT,
	Nombre NVARCHAR(100),
	Fecha_Nacimiento DATE
);

GO

INSERT INTO Personas(DNI,Nombre,Fecha_Nacimiento)
VALUES (353432432,'Sebastian', '1-1-1990'),
(35327489, 'Esteban', '1-1-1990'),
(43323432, 'Luisa', '5-1-2000'),
(30798132, 'Teresa', '3-26-1999'),
(35555132, 'Eduardo', '7-3-1995')

GO

DECLARE @Password NVARCHAR(255) = '123';
DECLARE @PasswordHash VARBINARY(64)= HASHBYTES('SHA2_256', CONVERT(VARCHAR(255), @Password, 2));
SELECT @PasswordHash 
--DECLARE @Base64Hash NVARCHAR(MAX);
--SET @Base64Hash = CAST('' AS XML).value('xs:base64Binary(sql:variable("@PasswordHash"))', 'NVARCHAR(MAX)');
--SELECT @Base64Hash;

DECLARE @uuid UNIQUEIDENTIFIER = NEWID();

INSERT INTO Usuarios(UUID, Nombre, Clave)
VALUES(@uuid, 'Admin', CONVERT(NVARCHAR(200), @PasswordHash,2))


GO

select  * from Usuarios

GO

--habilitando las conexiones remotas 
EXEC sp_configure 'show advanced options', 1;  
RECONFIGURE;  
EXEC sp_configure 'remote access', 1;  
RECONFIGURE;

GO
--conexiones mixtas
--EXEC xp_instance_regwrite N'HKEY_LOCAL_MACHINE', N'Software\Microsoft\MSSQLServer\MSSQLServer', N'LoginMode', REG_DWORD, 2;