
--cambio a master porque si esta abierta no la va a poder eliminar
USE MASTER

GO

DROP DATABASE IF EXISTS EjemploCRUDSimpleLoginDB

GO

CREATE DATABASE  EjemploCRUDSimpleLoginDB

GO

USE EjemploCRUDSimpleLoginDB

GO

CREATE TABLE Cuenta
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(50),
	Clave NVARCHAR(50),
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
(43323432, 'Luisa', '1-1-2000')