

## Ejemplo 1

Resumen

Este ejemplo mediante la implementaci�n de un ABM (Alta, Baja, Modificaci�n) o CRUD (Create, Remove, Update y Delete) sencillo busca implementar las p�ginas din�micas asociadas y la implementaci�n del patr�n DAO.


### (1) Servicio: 


La aplicaci�n web MVC y RestAPI estan en: `Ejemplo_01_0_CRUD_MVC_Simple`


### (2) Preparaci�n de la base de datos. 

En `Ejemplo_01_0_database_MSSQL` se encuentan los script T-SQL (Transaction SQL). 

- `local_script.sql`: es el script para correrlo en la base local.

- `docker_script.sql`: son los scripts para la creaci�n y ejecuci�n de los contenedores

- `somee_script.sql`: hay que primero crear la cuenta en somee.co, dar el alta de la base, conectarse usando el managemente de sql-server y luego correr el T-SQL

Cualquiera sea el caso elegido, hay que ajustar la cadena de conexi�n en `(1)` en la clase `Ejemplo_01_0_CRUD_MVC_Simple.DALs.MSSDALs.ConexionString`


