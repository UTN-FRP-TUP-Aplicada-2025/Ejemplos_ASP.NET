using ClienteAPI.Api; // Espacio de nombres generado
using ClienteAPI.Client; // Espacio de nombres para la configuración


        // Configurar la URL base de la API
        var config = new System.Configuration
        {
            BasePath = "http://localhost:5237"
        };

        // Crear una instancia del cliente
        var personasApi = new PersonasApi(config);

        try
        {
            // Llamar al endpoint GET /api/Personas
            var personas = await personasApi.ApiPersonasGetAsync();

            // Imprimir los resultados
            foreach (var persona in personas)
            {
                Console.WriteLine($"DNI: {persona.Dni}, Nombre: {persona.Nombre}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al consumir la API: {ex.Message}");
        }
