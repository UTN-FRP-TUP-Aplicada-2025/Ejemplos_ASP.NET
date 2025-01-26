
--Nombre del servidor: Ejemplos_ASP_MVC_DB.mssql.somee.com
--Usuario: fernando-dev_SQLLogin_1
--Password: bfzixu5w6p
--Nombre de la base de datos: Ejemplos_ASP_MVC_DB
--confiar en el certificado del servidor: true

USE Ejemplos_ASP_MVC_DB

GO

DROP TABLE IF EXISTS Personas

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