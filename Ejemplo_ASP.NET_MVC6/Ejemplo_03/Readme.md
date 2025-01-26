

## Ejemplo 3

Resumen

En este ejemplo trata de correr un servicio web - con páginas dinámicas y un RestAPI. Consumir el RestAPI con distintos clientes.


### (1) Servicio: 


La aplicación web MVC y RestAPI estan en: `Ejemplo_02_0_CRUD_RestAPI_y_MVC_Simple`


### (2) Preparación de la base de datos. 

En `Ejemplo_02_0_database_MSSQL` se encuentan los script T-SQL (Transaction SQL). 

- `local_script.sql`: es el script para correrlo en la base local.

- `docker_script.sql`: son los scripts para la creación y ejecución de los contenedores

- `somee_script.sql`: hay que primero crear la cuenta en somee.co, dar el alta de la base, conectarse usando el managemente de sql-server y luego correr el T-SQL

Cualquiera sea el caso elegido, hay que ajustar la cadena de conexión en `(1)` en la clase `Ejemplo_02_0_CRUD_RestAPI_y_MVC_Simple.DALs.MSSDALs.ConexionString`

