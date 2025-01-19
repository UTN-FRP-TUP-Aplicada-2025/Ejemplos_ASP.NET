
--cambio a master porque si esta abierta no la va a poder eliminar
USE MASTER

GO

DROP DATABASE IF EXISTS Ejemplo03CRUDSimpleLoginDB

GO

CREATE DATABASE  Ejemplo03CRUDSimpleLoginDB

GO

USE Ejemplo03CRUDSimpleLoginDB

GO

CREATE TABLE Cuentas
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

CREATE TABLE Cuentas_Roles
(
	Id_Cuenta INT NOT NULL,
	Id_Rol INT NOT NULL,
	CONSTRAINT UQ_Cuentas_Roles UNIQUE (Id_Cuenta, Id_Rol)
);
--O

--CREATE TABLE Cuentas_Roles
--(
--	Id_Cuenta INT NOT NULL,
--	Id_Rol INT NOT NULL,
--	PRIMARY KEY (Id_Cuenta, Id_Rol)
--);

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

--habilitando las conexiones remotas 
EXEC sp_configure 'show advanced options', 1;  
RECONFIGURE;  
EXEC sp_configure 'remote access', 1;  
RECONFIGURE;

--conexiones mixtas
--EXEC xp_instance_regwrite N'HKEY_LOCAL_MACHINE', N'Software\Microsoft\MSSQLServer\MSSQLServer', N'LoginMode', REG_DWORD, 2;