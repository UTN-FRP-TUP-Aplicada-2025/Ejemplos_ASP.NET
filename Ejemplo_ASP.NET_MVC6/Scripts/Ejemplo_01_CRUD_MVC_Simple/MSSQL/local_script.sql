
--cambio a master porque si esta abierta no la va a poder eliminar
USE MASTER

GO


DROP DATABASE IF EXISTS Ejemplo_01_CRUD_MVC_Simple_DB

GO

CREATE DATABASE  Ejemplo_01_CRUD_MVC_Simple_DB

GO

USE Ejemplo_01_CRUD_MVC_Simple_eDB

GO

CREATE TABLE Personas
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	DNI INT,
	Nombre NVARCHAR(100),
);

GO

INSERT INTO Personas(DNI,Nombre)
VALUES (353432432,'Sebastian'),
(35327489, 'Esteban'),
(43323432, 'Luisa'),
(30798132, 'Teresa'),
(35555132, 'Eduardo')