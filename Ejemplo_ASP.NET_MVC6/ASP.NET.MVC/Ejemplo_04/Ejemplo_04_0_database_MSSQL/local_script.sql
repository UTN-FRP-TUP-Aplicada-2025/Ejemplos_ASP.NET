
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
	Nombre NVARCHAR(50) PRIMARY KEY NOT NULL,
	Clave NVARCHAR(200) NOT NULL,
);

CREATE TABLE Roles
(
	Nombre NVARCHAR(50) PRIMARY KEY NOT NULL,
);

CREATE TABLE  Usuarios_Roles
(
	Nombre_Usuario INT NOT NULL,
	Nombre_Rol INT NOT NULL,
	CONSTRAINT UQ_Usuarios_Roles UNIQUE (Nombre_Usuario, Nombre_Rol)
);

CREATE TABLE Personas
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	DNI INT NOT NULL,
	Nombre NVARCHAR(100) NOT NULL,
	Fecha_Nacimiento DATE
);

GO

INSERT INTO Personas(DNI,Nombre,Fecha_Nacimiento)
VALUES 
(35843243,'Sebastian', '1-1-1990'),
(35327489, 'Esteban', '1-1-1990'),
(43323432, 'Luisa', '5-1-2000'),
(30798132, 'Teresa', '3-26-1999'),
(35555132, 'Eduardo', '7-3-1995'),
(26555132, 'Rosa', '7-3-1975'),
(28451182, 'Griselda', '7-26-1982'),
(28733932, 'Carina', '7-23-1982'),
(24254932, 'Arturo', '6-2-1963'),
(28374602, 'Andres', '3-2-1980'),
(30694152, 'Estefania', '5-2-1985')

INSERT INTO Usuarios(Nombre, Clave)
VALUES('Admin', '123'),
('Usuario', 'abc');

GO

select * from Personas;

select * from Usuarios;


GO



--DECLARE @Password NVARCHAR(255) = '123';
--DECLARE @PasswordHash VARBINARY(64)= HASHBYTES('SHA2_256', CONVERT(VARCHAR(255), @Password, 2));
--SELECT @PasswordHash 
--DECLARE @Base64Hash NVARCHAR(MAX);
--SET @Base64Hash = CAST('' AS XML).value('xs:base64Binary(sql:variable("@PasswordHash"))', 'NVARCHAR(MAX)');
--SELECT @Base64Hash;

--DECLARE @uuid UNIQUEIDENTIFIER = NEWID();

--INSERT INTO Usuarios(UUID, Nombre, Clave)
--VALUES(@uuid, 'Admin', CONVERT(NVARCHAR(200), @PasswordHash,2))
