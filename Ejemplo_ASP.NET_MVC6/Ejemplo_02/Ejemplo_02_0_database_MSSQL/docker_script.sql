
--cambio a master porque si esta abierta no la va a poder eliminar
USE MASTER

GO

DROP DATABASE IF EXISTS Ejemplo_02_0_CRUD_RestAPI_y_MVC_Simple_DB

GO

CREATE DATABASE Ejemplo_02_0_CRUD_RestAPI_y_MVC_Simple_DB

GO

USE Ejemplo_02_0_CRUD_RestAPI_y_MVC_Simple_DB

GO

CREATE TABLE Personas
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	DNI INT NOT NULL,
	Nombre NVARCHAR(100) NOT NULL,
	Fecha_Nacimiento DATE
);

GO

INSERT INTO Personas(DNI,Nombre,Fecha_Nacimiento)
VALUES (353432432,'Sebastian', '1-1-1990'),
(35327489, 'Esteban', '1-1-1990'),
(43323432, 'Luisa', '5-1-2000'),
(30798132, 'Teresa', '3-26-1999'),
(35555132, 'Eduardo', '7-3-1995'),
(26555132, 'Rosa', '7-3-1975'),
(28451182, 'Griselda', '7-26-1982'),
(28733932, 'Carina', '7-23-1982')

GO

--habilitando las conexiones remotas 
EXEC sp_configure 'show advanced options', 1;  
RECONFIGURE;  
EXEC sp_configure 'remote access', 1;  
RECONFIGURE;

GO