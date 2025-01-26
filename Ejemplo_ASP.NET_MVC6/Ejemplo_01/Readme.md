

## Ejemplo 1

Resumen

Este ejemplo mediante la implementación de un ABM (Alta, Baja, Modificación) o CRUD (Create, Remove, Update y Delete) sencillo busca implementar las páginas dinámicas asociadas y la implementación del patrón DAO.


### (1) Servicio: 


La aplicación web MVC y RestAPI estan en: `Ejemplo_01_0_CRUD_MVC_Simple`


### (2) Preparación de la base de datos. 

En `Ejemplo_01_0_database_MSSQL` se encuentan los script T-SQL (Transaction SQL). 

- `local_script.sql`: es el script para correrlo en la base local.

- `docker_script.sql`: son los scripts para la creación y ejecución de los contenedores

- `somee_script.sql`: hay que primero crear la cuenta en somee.co, dar el alta de la base, conectarse usando el managemente de sql-server y luego correr el T-SQL

Cualquiera sea el caso elegido, hay que ajustar la cadena de conexión en `(1)` en la clase `Ejemplo_01_0_CRUD_MVC_Simple.DALs.MSSDALs.ConexionString`


