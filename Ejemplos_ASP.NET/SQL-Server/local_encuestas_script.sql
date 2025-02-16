
-- en desarrollo

GO

--Instancias de las encuenstas
CREATE TABLE Encuentas
(
	Id INT IDENTITY(1,1),
	Periodo INT NOT NULL UNIQUE,	
	--
	CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF,
            ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON,
            OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY];


GO

CREATE TABLE Encuestador
(
	Id INT IDENTITY(1,1)
);

GO

-- relaciona a las encuestas los encuestadores
CREATE TABLE Encuestas_Encuestador
(
	Id INT IDENTITY(1,1),
	--
	Id_Encuesta INT NOT NULL,
	Id_Encuestador INT NOT NULL,
);

GO

-- la idea es hacer una base de preguntas y relacionarla con la instancia de la encuesta
CREATE TABLE Consultas
(
	Id INT IDENTITY(1,1),
	--
	Pregunta NVARCHAR(100) NOT NULL,
);

GO

CREATE TABLE Cuestionarios
(
	Id INT IDENTITY(1,1),
	--
    Email NVARCHAR(100) NOT NULL UNIQUE,  
	--
	Id_Encuesta INT NOT NULL,
	Id_Encuestador INT NOT NULL
);

GO

CREATE TABLE Encuestador
(
	Id INT IDENTITY(1,1),
	--
	Id_CuentaUsuario INT NOT NULL
);
