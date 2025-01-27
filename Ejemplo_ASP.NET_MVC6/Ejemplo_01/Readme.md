

## Ejemplo 1

Resumen

Este ejemplo mediante la implementación de un ABM (Alta, Baja, Modificación) o CRUD (Create, Remove, Update y Delete) sencillo busca implementar las páginas dinámicas asociadas y la implementación del patrón DAO.


### (1) Servicio: 


La aplicación web MVC y RestAPI estan en: `Ejemplo_01_0_CRUD_MVC_Simple`


### (2) Preparación de la base de datos. 

En `Ejemplo_01_0_database_MSSQL` se encuentan los script T-SQL (Transaction SQL). 

- `local_script.sql`: es el script para correrlo en la base local.

- `docker_script.sql`: son los scripts para la creación y ejecución de los contenedores

- `somee_script.sql`: hay que primero crear la cuenta en somee.com, dar el alta de la base, conectarse usando el managemente de sql-server y luego correr el T-SQL

Cualquiera sea el caso elegido, hay que ajustar la cadena de conexión en `(1)` en la clase `Ejemplo_01_0_CRUD_MVC_Simple.DALs.MSSDALs.ConexionString`


### Program.cs

#### Resumen
Primero se crea el contenedor, se configuran los servicios y luego se conectan esos servicios a un middleware por medio o en un pipeline. 

#### Desarrollo

##### 1. Contenedor de Dependencias (DI Container)

El contenedor de dependencias es ==el motor que maneja todos los servicios que la aplicación necesita==. En ASP.NET Core, este contenedor se configura usando `builder.Services` durante la fase de creación de la aplicación. Los servicios pueden ser cosas como la autenticación, bases de datos, servicios personalizados, controladores, y más.

==El contenedor mantiene un registro de esos servicios y sus dependencias==. Básicamente, el contenedor sabe cómo crear y gestionar estos servicios cuando la aplicación los necesite.

Cuando se llama a `builder.Services.AddAuthentication()`, el contenedor registra todo lo necesario para que el sistema de autenticación funcione.

==¿Qué hace el contenedor?:==

En el contenedor contendrá todos los objetos necesarios y se encargará de inyectarlos donde se haya indicando.
En el se preparan todos los servicios y las configuraciones que la aplicación necesita para funcionar.

##### 2. Middleware

El middleware son piezas de código que interceptan y procesan cada solicitud HTTP que llega a la aplicación. Los middleware se agregan al pipeline de la aplicación, y se ejecutan en un orden específico. Son como filtros o etapas por las que pasan las solicitudes antes de que lleguen a su destino final (por ejemplo, un controlador).

Cuando se llama a `app.UseAuthentication()`, se indica que con este middleware verifique si la solicitud tiene credenciales de autenticación válidas. Si no las tiene, puede redirigir al usuario al login, por ejemplo.

==¿Qué hace el middleware?:==

Modifica o decide cómo tratar las solicitudes antes de que lleguen a su destino.

##### 3. Pipeline

El pipeline es el camino de ejecución por donde pasan las solicitudes HTTP. El pipeline está formado por una cadena de middleware que se ejecutan en el orden en que han sido agregados. Cada middleware en el pipeline tiene una oportunidad de procesar la solicitud, modificarla, o detenerla (como ocurre en los sistemas de autenticación o autorización).

Si se tiene las siguientes invocaciones  `app.UseAuthentication()`, `app.UseAuthorization()`, y `app.UseRouting()`, cada uno de esos middleware será parte del pipeline y se ejecutará secuencialmente, procesando la solicitud de la forma que se haya configurado.

==¿Qué hace el pipeline?:==

Define el flujo de la solicitud a través de los middleware. A medida que la solicitud avanza, el pipeline puede modificarla, detenerla o redirigirla.

##### Relación entre Contenedor, Middleware y Pipeline

==Contenedor de Dependencias:==

Durante la creación de la aplicación con `WebApplication.CreateBuilder()`, se configura y registra todos los servicios que la aplicación va a necesitar. Estos servicios se gestionan a través del contenedor de dependencias.

==Servicios del Contenedor y Middleware:==

Algunos de esos servicios, como la autenticación (AddAuthentication), la autorización (AddAuthorization), y las sesiones (AddSession), son configurados dentro de los middleware. Así que, aunque los servicios se definen en el contenedor, el middleware se asegura de que esos servicios sean usados correctamente en cada solicitud HTTP que entra.

==Pipeline:==

El pipeline es donde esos servicios y middleware interactúan. Cuando se agrega un middleware con `app.UseX()`, básicamente se le está diciendo a la aplicación que ejecute ese servicio en el pipeline en un orden específico, para que se encargue de las solicitudes en el camino.

==Ejemplo del flujo de creación de la aplicación==

1- El contenedor asegurará que los servicios de autenticación y autorización estén disponibles.

2- Los middleware (como `UseAuthentication`, `UseAuthorization`, `UseRouting`) se encargan de procesar la solicitud. En otras palabras se configura el comportamiento de la aplicación en cada solicitud HTTP, utilizando los servicios del contenedor.

3- ElPipeline es la secuencia de ejecución que pasa la solicitud por estos middleware. Es el camino por el que viajan las solicitudes, pasando por los middleware en un orden secuencial para ser procesadas.

```csharp
var builder = WebApplication.CreateBuilder(args);

//configura el contenedor con los servicios que la app necesita.
builder.Services.AddAuthentication("Cookies");  // Servicio de autenticación
builder.Services.AddAuthorization();  // Servicio de autorización

var app = builder.Build();

//se agrega los middleware al pipeline para gestionar las solicitudes HTTP.
app.UseAuthentication();  //verifica si la solicitud está autenticada.
app.UseAuthorization();   //verifica si la solicitud tiene permisos para acceder.
app.UseRouting();         //encuentra la ruta que corresponde a la solicitud.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
```




