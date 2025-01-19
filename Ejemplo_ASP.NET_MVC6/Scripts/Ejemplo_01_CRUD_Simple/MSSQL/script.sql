
--cambio a master porque si esta abierta no la va a poder eliminar
USE MASTER

GO


DROP DATABASE IF EXISTS Ejemplo01CRUDSimpleDB

GO

CREATE DATABASE  Ejemplo01CRUDSimpleDB

GO

USE Ejemplo01CRUDSimpleDB

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