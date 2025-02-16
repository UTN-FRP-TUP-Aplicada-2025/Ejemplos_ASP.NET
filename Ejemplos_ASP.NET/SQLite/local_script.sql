
CREATE DATABASE MyFirstDatabase;
>sqlite3 personas_db.db

-- Crear la tabla Usuarios
CREATE TABLE IF NOT EXISTS Usuarios (
    Nombre TEXT PRIMARY KEY NOT NULL,
    Clave TEXT NOT NULL
);

-- Crear la tabla Roles
CREATE TABLE IF NOT EXISTS Roles (
    Nombre TEXT PRIMARY KEY NOT NULL
);

-- Crear la tabla Usuarios_Roles con claves foráneas
CREATE TABLE IF NOT EXISTS Usuarios_Roles (
    Nombre_Usuario TEXT NOT NULL,
    Nombre_Rol TEXT NOT NULL,
    CONSTRAINT UQ_Usuarios_Roles UNIQUE (Nombre_Usuario, Nombre_Rol),
    CONSTRAINT FK_Usuarios_Roles_Usuarios FOREIGN KEY (Nombre_Usuario) REFERENCES Usuarios(Nombre) ON DELETE CASCADE,
    CONSTRAINT FK_Usuarios_Roles_Roles FOREIGN KEY (Nombre_Rol) REFERENCES Roles(Nombre) ON DELETE CASCADE
);

-- Crear la tabla Personas
CREATE TABLE IF NOT EXISTS Personas (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    DNI INT NOT NULL UNIQUE,
    Nombre TEXT NOT NULL,
    Fecha_Nacimiento DATE
);

-- Insertar datos en la tabla Personas
INSERT INTO Personas (DNI, Nombre, Fecha_Nacimiento) VALUES 
(35843243, 'Sebastian', '1990-01-01'),
(35327489, 'Esteban', '1990-01-01'),
(43323432, 'Luisa', '2000-01-05'),
(30798132, 'Teresa', '1999-03-26'),
(35555132, 'Eduardo', '1995-07-03'),
(26555132, 'Rosa', '1975-07-03'),
(28451182, 'Griselda', '1982-07-26'),
(28733932, 'Carina', '1982-07-23'),
(24254932, 'Arturo', '1963-06-02'),
(28374602, 'Andres', '1980-03-02'),
(30694152, 'Estefania', '1985-05-02'),
(45235754, 'Norberto', '2004-02-06'),
(32432223, 'Ricardo', '2000-02-06'),
(23432224, 'Aurelio', '2004-02-06'),
(37232632, 'Cesar', '1987-02-02'),
(37237202, 'David', '1987-02-02'),
(37232432, 'Patricia', '1987-02-02'),
(37232932, 'Analía', '1987-02-02'),
(32042032, 'Dolores', '1987-02-02'),
(34237032, 'Gustavo', '1987-02-02'),
(42232072, 'Marianela', '1987-02-02'),
(37234210, 'Andrea', '1987-02-02'),
(37238236, 'Rita', '1987-02-02');

-- Insertar datos en la tabla Usuarios
INSERT INTO Usuarios (Nombre, Clave) VALUES
('Admin', '123'),
('Eduardo', 'eduardo'),
('Estefania', 'estefania');

-- Insertar datos en la tabla Roles
INSERT INTO Roles (Nombre) VALUES
('Admin'),
('Encuestador'),
('Supervisor');

-- Insertar datos en la tabla Usuarios_Roles
INSERT INTO Usuarios_Roles (Nombre_Usuario, Nombre_Rol) VALUES
('Eduardo', 'Admin'),
('Estefania', 'Supervisor'),
('Eduardo', 'Encuestador');

-- Consultar datos de las tablas
SELECT * FROM Personas;
SELECT * FROM Usuarios;
SELECT * FROM Usuarios_Roles;

-- Consultar los roles de 'Estefania'
SELECT r.Nombre 
FROM Usuarios u
INNER JOIN Usuarios_Roles u_r ON u_r.Nombre_Usuario = u.Nombre
INNER JOIN Roles r ON r.Nombre = u_r.Nombre_Rol
WHERE UPPER(u.Nombre) = 'ESTEFANIA';
