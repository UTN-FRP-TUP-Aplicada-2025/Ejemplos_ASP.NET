

## Ejemplo 1

Resumen

Este ejemplo mediante la implementaci�n de un ABM (Alta, Baja, Modificaci�n) o CRUD (Create, Remove, Update y Delete) sencillo busca implementar las p�ginas din�micas asociadas y la implementaci�n del patr�n DAO.


### (1) Servicio: 


La aplicaci�n web MVC y RestAPI estan en: `Ejemplo_01_0_CRUD_MVC_Simple`


### (2) Preparaci�n de la base de datos. 

En `Ejemplo_01_0_database_MSSQL` se encuentan los script T-SQL (Transaction SQL). 

- `local_script.sql`: es el script para correrlo en la base local.

- `docker_script.sql`: son los scripts para la creaci�n y ejecuci�n de los contenedores

- `somee_script.sql`: hay que primero crear la cuenta en somee.com, dar el alta de la base, conectarse usando el managemente de sql-server y luego correr el T-SQL

Cualquiera sea el caso elegido, hay que ajustar la cadena de conexi�n en `(1)` en la clase `Ejemplo_01_0_CRUD_MVC_Simple.DALs.MSSDALs.ConexionString`


### Program.cs

#### Resumen
Primero se crea el contenedor, se configuran los servicios y luego se conectan esos servicios a un middleware por medio o en un pipeline. 

#### Desarrollo

##### 1. Contenedor de Dependencias (DI Container)

El contenedor de dependencias es ==el motor que maneja todos los servicios que la aplicaci�n necesita==. En ASP.NET Core, este contenedor se configura usando `builder.Services` durante la fase de creaci�n de la aplicaci�n. Los servicios pueden ser cosas como la autenticaci�n, bases de datos, servicios personalizados, controladores, y m�s.

==El contenedor mantiene un registro de esos servicios y sus dependencias==. B�sicamente, el contenedor sabe c�mo crear y gestionar estos servicios cuando la aplicaci�n los necesite.

Cuando se llama a `builder.Services.AddAuthentication()`, el contenedor registra todo lo necesario para que el sistema de autenticaci�n funcione.

==�Qu� hace el contenedor?:==

En el contenedor contendr� todos los objetos necesarios y se encargar� de inyectarlos donde se haya indicando.
En el se preparan todos los servicios y las configuraciones que la aplicaci�n necesita para funcionar.

##### 2. Middleware

El middleware son piezas de c�digo que interceptan y procesan cada solicitud HTTP que llega a la aplicaci�n. Los middleware se agregan al pipeline de la aplicaci�n, y se ejecutan en un orden espec�fico. Son como filtros o etapas por las que pasan las solicitudes antes de que lleguen a su destino final (por ejemplo, un controlador).

Cuando se llama a `app.UseAuthentication()`, se indica que con este middleware verifique si la solicitud tiene credenciales de autenticaci�n v�lidas. Si no las tiene, puede redirigir al usuario al login, por ejemplo.

==�Qu� hace el middleware?:==

Modifica o decide c�mo tratar las solicitudes antes de que lleguen a su destino.

##### 3. Pipeline

El pipeline es el camino de ejecuci�n por donde pasan las solicitudes HTTP. El pipeline est� formado por una cadena de middleware que se ejecutan en el orden en que han sido agregados. Cada middleware en el pipeline tiene una oportunidad de procesar la solicitud, modificarla, o detenerla (como ocurre en los sistemas de autenticaci�n o autorizaci�n).

Si se tiene las siguientes invocaciones  `app.UseAuthentication()`, `app.UseAuthorization()`, y `app.UseRouting()`, cada uno de esos middleware ser� parte del pipeline y se ejecutar� secuencialmente, procesando la solicitud de la forma que se haya configurado.

==�Qu� hace el pipeline?:==

Define el flujo de la solicitud a trav�s de los middleware. A medida que la solicitud avanza, el pipeline puede modificarla, detenerla o redirigirla.

##### Relaci�n entre Contenedor, Middleware y Pipeline

==Contenedor de Dependencias:==

Durante la creaci�n de la aplicaci�n con `WebApplication.CreateBuilder()`, se configura y registra todos los servicios que la aplicaci�n va a necesitar. Estos servicios se gestionan a trav�s del contenedor de dependencias.

==Servicios del Contenedor y Middleware:==

Algunos de esos servicios, como la autenticaci�n (AddAuthentication), la autorizaci�n (AddAuthorization), y las sesiones (AddSession), son configurados dentro de los middleware. As� que, aunque los servicios se definen en el contenedor, el middleware se asegura de que esos servicios sean usados correctamente en cada solicitud HTTP que entra.

==Pipeline:==

El pipeline es donde esos servicios y middleware interact�an. Cuando se agrega un middleware con `app.UseX()`, b�sicamente se le est� diciendo a la aplicaci�n que ejecute ese servicio en el pipeline en un orden espec�fico, para que se encargue de las solicitudes en el camino.

==Ejemplo del flujo de creaci�n de la aplicaci�n==

1- El contenedor asegurar� que los servicios de autenticaci�n y autorizaci�n est�n disponibles.

2- Los middleware (como `UseAuthentication`, `UseAuthorization`, `UseRouting`) se encargan de procesar la solicitud. En otras palabras se configura el comportamiento de la aplicaci�n en cada solicitud HTTP, utilizando los servicios del contenedor.

3- ElPipeline es la secuencia de ejecuci�n que pasa la solicitud por estos middleware. Es el camino por el que viajan las solicitudes, pasando por los middleware en un orden secuencial para ser procesadas.

```csharp
var builder = WebApplication.CreateBuilder(args);

//configura el contenedor con los servicios que la app necesita.
builder.Services.AddAuthentication("Cookies");  // Servicio de autenticaci�n
builder.Services.AddAuthorization();  // Servicio de autorizaci�n

var app = builder.Build();

//se agrega los middleware al pipeline para gestionar las solicitudes HTTP.
app.UseAuthentication();  //verifica si la solicitud est� autenticada.
app.UseAuthorization();   //verifica si la solicitud tiene permisos para acceder.
app.UseRouting();         //encuentra la ruta que corresponde a la solicitud.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
```




