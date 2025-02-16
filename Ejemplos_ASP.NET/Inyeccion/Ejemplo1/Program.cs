using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


var configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

//depedencias
var serviceProvider = new ServiceCollection()

    //Singleton crea una sola instancia del servicio durante el tiempo de vida de la aplicación.
    //- mantener estado global o compartir datos entre diferentes partes de la aplicación.
    //- para servicios pesados o que realizan cálculos costosos de inicialización.
    //-  Clientes de conexión a base de datos, proveedores de configuración, servicios de caching.
    .AddSingleton<IConfiguration>(configuration)

    //Transient crea una nueva instancia del servicio cada vez que se solicita.
    //-no necesitas mantener estado entre llamadas.
    //-para servicios ligeros que no requieren inicialización costosa.
    .AddTransient<IMiServicio, MiServicio>()

    .BuildServiceProvider();

var servicio = serviceProvider.GetService<IMiServicio>();
servicio.MostrarConexion();

