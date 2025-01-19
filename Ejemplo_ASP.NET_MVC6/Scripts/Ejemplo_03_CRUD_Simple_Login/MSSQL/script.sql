
--cambio a master porque si esta abierta no la va a poder eliminar
USE MASTER

GO

DROP DATABASE IF EXISTS EjemploCRUDSimpleLoginDB

GO

CREATE DATABASE  EjemploCRUDSimpleLoginDB

GO

USE EjemploCRUDSimpleLoginDB

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