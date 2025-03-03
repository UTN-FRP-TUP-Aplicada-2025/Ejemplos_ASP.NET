
/* 1- Construcción del contenedor de la aplicación

 La principal función de CreateBuilder es configurar y construir el contenedor
 de dependencias (DI) de la aplicación.
 El contenedor de dependencias es un sistema que maneja todas las instancias de
 servicios que tu aplicación necesita durante su ejecución.
 En este se agregan los servicios como
 -Controladores (para manejar las solicitudes HTTP)
 -Middleware (como autenticación, autorización, manejo de errores)
 -Acceso a bases de datos (como Entity Framework o servicios de base de datos)
 -Servicios personalizados
*/


using Ejemplo_15_personas_datoslib.DALs;
using Ejemplo_15_personas_datoslib.DALs.MSSDALs;
using Ejemplo_15_personas_datoslib.Services;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Ejemplo: registrando servicios para el uso de controladores MVC
builder.Services.AddControllersWithViews();

#region creando el contexto
builder.Services.AddTransient<SqlConnection>(sp =>
      {
          var configuration = sp.GetService<IConfiguration>();
          var connectionString = configuration.GetConnectionString("CadenaConexion");
          return new SqlConnection(connectionString);
      });

//La conexión se mantiene viva solo durante la duración de una solicitud HTTP.
//Es más eficiente en aplicaciones con múltiples solicitudes simultáneas.
builder.Services.AddScoped<ITransaction<SqlTransaction>, SqlServerTransaction>();

builder.Services.AddScoped<PersonasMSSDAL>();
builder.Services.AddScoped<UsuariosMSSDAL>();
builder.Services.AddScoped<RolesMSSDAL>();
builder.Services.AddScoped<UsuariosRolesMSSDAL>();
//
builder.Services.AddScoped<PersonasService>();
builder.Services.AddScoped<CuentasService>();
builder.Services.AddScoped<RolesService>();
#endregion

/* 2- Construcción de la aplicación
 
app es el objeto que va a manejar las solicitudes y las respuestas de los usuarios. Construye la aplicación, conectando todos esos servicios y configuraciones en un pipeline de middleware.
 */

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// redirige las consultas de los usuarios a HTTPS sino estan usando este protocolo
app.UseHttpsRedirection();

app.UseStaticFiles();

// prepara la app para que pueda redirigir las solicitudes a la ruta requerida
app.UseRouting();

// verifica permisos de acceso a los recursos
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
