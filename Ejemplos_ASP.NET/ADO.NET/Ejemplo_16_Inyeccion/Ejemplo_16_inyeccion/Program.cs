using Ejemplo_15_personas_datoslib.DALs;
using Ejemplo_15_personas_datoslib.DALs.MSSDALs;
using Ejemplo_15_personas_datoslib.Services;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

//depedencias
var serviceProvider = new ServiceCollection()

    //Crea una sola instancia del servicio durante el tiempo de vida de la aplicación.
    .AddSingleton<IConfiguration>(configuration)

     //La conexión se mantiene viva solo durante la duración de una solicitud HTTP.
     //Es más eficiente en aplicaciones con múltiples solicitudes simultáneas.
     .AddScoped<SqlConnection>(sp =>
     {
         var configuration = sp.GetService<IConfiguration>();
         var connectionString = configuration.GetConnectionString("CadenaConexion");
         return new SqlConnection(connectionString);
     })
    .AddScoped<ITransaction<SqlTransaction>, SqlServerTransaction>()

    .AddSingleton<PersonasMSSDAL>()
    .AddSingleton<UsuariosMSSDAL>()
    .AddSingleton<RolesMSSDAL>()
    .AddSingleton<UsuariosRolesMSSDAL>()
    .AddSingleton<PersonasService>()
    .AddSingleton<CuentasService>()
    .AddSingleton<RolesService>()

    .BuildServiceProvider();

//var servicio = serviceProvider.GetService<IMiServicio>();
//servicio.MostrarConexion();

//test local

var servicio = serviceProvider.GetService<PersonasService>();
foreach (var item in await servicio.GetAll())
{
    Console.WriteLine(item.Nombre);
}

