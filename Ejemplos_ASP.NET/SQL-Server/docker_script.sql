
--cambio a master porque si esta abierta no la va a poder eliminar
USE MASTER

GO

DROP DATABASE IF EXISTS Ejemplo_05_0_Roles_Login_DB

GO

CREATE DATABASE  Ejemplo_05_0_Roles_Login_DB

GO

USE Ejemplo_05_0_Roles_Login_DB

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
	Nombre_Usuario NVARCHAR(50) NOT NULL,
	Nombre_Rol NVARCHAR(50) NOT NULL,
	CONSTRAINT UQ_Usuarios_Roles UNIQUE (Nombre_Usuario, Nombre_Rol)
);

GO 

ALTER TABLE Usuarios_Roles
ADD CONSTRAINT FK_Usuarios_Roles_Roles
FOREIGN KEY (Nombre_Rol) REFERENCES Roles(Nombre);

ALTER TABLE Usuarios_Roles
ADD CONSTRAINT FK_Usuarios_Roles_Usuarios
FOREIGN KEY (Nombre_Usuario) REFERENCES Usuarios(Nombre);

GO

CREATE TABLE Personas
(
	Id INT IDENTITY(1,1),
	DNI INT NOT NULL,
	Nombre NVARCHAR(100) NOT NULL,
	Fecha_Nacimiento DATE,
	--
	CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF,
            ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON,
            OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY];



GO

INSERT INTO Personas(DNI,Nombre,Fecha_Nacimiento)
VALUES 
(35843243, 'Sebastian', '1-1-1990'),
(35327489, 'Esteban', '1-1-1990'),
(43323432, 'Luisa', '5-1-2000'),
(30798132, 'Teresa', '3-26-1999'),
(35555132, 'Eduardo', '7-3-1995'),
(26555132, 'Rosa', '7-3-1975'),
(28451182, 'Griselda', '7-26-1982'),
(28733932, 'Carina', '7-23-1982'),
(24254932, 'Arturo', '6-2-1963'),
(28374602, 'Andres', '3-2-1980'),
(30694152, 'Estefania', '5-2-1985'),
(45235754, 'Norberto', '2-6-2004'),
(32432223, 'Ricardo', '2-6-2000'),
(23432224, 'Aurelio', '2-6-2004'),
(37232232, 'Cesar', '2-2-1987')

INSERT INTO Usuarios(Nombre, Clave)
VALUES('Admin', '123'),
('Eduardo', 'eduardo'),
('Estefania', 'estefania');

INSERT INTO Roles(Nombre)
VALUES('Admin'),
('Encuestador'),
('Supervisor');

INSERT INTO Usuarios_Roles(Nombre_Usuario, Nombre_Rol)
VALUES
('Eduardo', 'Admin'),
('Estefania', 'Supervisor'),
('Eduardo', 'Encuestador');

GO

select * from Personas;

select * from Usuarios;

select * from Usuarios_Roles;

GO

--roles de estafania
DECLARE @Estefania NVARCHAR(50)='Estefania';

SELECT r.Nombre
FROM Usuarios u
INNER JOIN Usuarios_Roles u_r ON u_r.Nombre_Usuario=u.Nombre
INNER JOIN Roles r ON r.Nombre=u_r.Nombre_Rol
WHERE UPPER(u.Nombre)=UPPER(@Estefania)

GO


--habilitando las conexiones remotas 
EXEC sp_configure 'show advanced options', 1;  
RECONFIGURE;  
EXEC sp_configure 'remote access', 1;  
RECONFIGURE;

GO