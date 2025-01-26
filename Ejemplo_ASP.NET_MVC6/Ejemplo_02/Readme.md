

## Ejemplo 2

Resumen

En este ejemplo trata de correr un servicio web - con páginas dinámicas y un RestAPI. Consumir el RestAPI con distintos clientes.


### (1) Servicio: 


La aplicación web MVC y RestAPI estan en:

`Ejemplo_02_0_CRUD_RestAPI_y_MVC_Simple`


### (2) Preparación de la base de datos. 

En `Ejemplo_02_0_database_MSSQL` se encuentan los script T-SQL (Transaction SQL). 

- `local_script.sql`: es el script para correrlo en la base local.

- `docker_script.sql`: son los scripts para la creación y ejecución de los contenedores

- `somee_script.sql`: hay que primero crear la cuenta en somee.co, dar el alta de la base, conectarse usando el managemente de sql-server y luego correr el T-SQL

Cualquiera sea el caso elegido, hay que ajustar la cadena de conexión en `(1)` en la clase `Ejemplo_02_0_CRUD_RestAPI_y_MVC_Simple.DALs.MSSDALs.ConexionString`

### (3) Cliente Windows Form

es una aplicación de escritorio que se conecta al servicio RestAPI `(1)` y recupera el listado de personas mostrandolas en una grilla.

```csharp
using var client = new HttpClient();

var consulta = new HttpRequestMessage(HttpMethod.Get, url);

var respuesta = await client.SendAsync(consulta);

if (respuesta.IsSuccessStatusCode)
{
  var json = await respuesta.Content.ReadAsStringAsync();
  personas = JsonSerializer.Deserialize<List<PersonaDTO>>(json);
}
```

### (4) Cliente javascript

Es una página sencilla en HTML con un javascript embebido en la misma que se conecta al servicio RestAPI `(1)` recuperando el listado de personas y creando dinámicamente una tabla con este contenido.

Para correrlo, tener el servicio en ejecución, y abrir dicha página con chrome (click derecho, abrir como, elegir chrome)

Para llamar el servicio RestAPI desde java script se usó el siguiente código:
```javascript
fetch('https://localhost:7154/api/Personas', { method: 'GET', headers: { 'accept': '*/*'} })
.then(response => 
{
	if (!response.ok) 
	{
		throw new Error(`HTTP error! status: ${response.status}`);
	}
	return response.json(); //deserialización
})
.then(data => {
	mostrarTabla(data); //dibujar la tabla
})
.catch(error => {
	console.error('Error:', error);
});
```

### (5) Cliente Powershell

Powershell es un interprete de comandos similar al viejo CMD, es más complejo que su interprete de comandos antecesor, y ha sido dotado de funciones más complejas y avanzadas.

El script permite llamar al servicio RestAPI `(1)` y mostrar el listado de personas proporcionado por el RestAPI `(1)`.



### (6) Dockerización

Estan los scripts y los dockerfile para crear las imagenes y contenedores dentro del space code git

