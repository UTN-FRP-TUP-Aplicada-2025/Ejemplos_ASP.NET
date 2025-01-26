
--cambio a master porque si esta abierta no la va a poder eliminar
USE MASTER

GO

DROP DATABASE IF EXISTS Ejemplo_03_Login_Simple_DB

GO

CREATE DATABASE Ejemplo_03_Login_Simple_DB

GO

USE Ejemplo_03_Login_Simple_DB

GO

CREATE TABLE Usuarios
(
	Nombre NVARCHAR(50) PRIMARY KEY NOT NULL,
	Clave NVARCHAR(200) NOT NULL,
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
VALUES (353432432,'Sebastian', '1-1-1990'),
(35327489, 'Esteban', '1-1-1990'),
(43323432, 'Luisa', '5-1-2000'),
(30798132, 'Teresa', '3-26-1999'),
(35555132, 'Eduardo', '7-3-1995'),
(40795232, 'Rosa', '1-6-2005'),
(41957210, 'Griselda', '10-25-2005')

GO


INSERT INTO Usuarios(Nombre, Clave)
VALUES('Admin', '123'),
('Usuario', 'abc')

GO

select * from Usuarios


