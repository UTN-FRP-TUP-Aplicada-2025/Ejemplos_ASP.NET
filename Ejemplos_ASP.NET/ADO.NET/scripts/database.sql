DROP TABLE IF EXISTS Personas ;

GO

CREATE TABLE Personas
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50),
);

GO

INSERT INTO Personas (Nombre)
VALUES
('Guido'),
('José'),
('Máxima'),
('Renzo')

GO

SELECT p.* FROM Personas p