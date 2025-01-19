# Ejemplos_ASP.NET_MVC6


borrando contenedores detenidas e imagenes no utilizadas

docker containter prune
docker image prune -a
docker network prune

borra hasta la cache
docker system prune -a --volumes
docker system prune --all --force


IP="$(docker inspect -f '{{range.NetworkSettings.Networks}}{{.IPAddress}}{{end}}' ejemplo03_dotnet_container)"
echo $IP

root@9ca5901163a9:/app# export ASPNETCORE_URLS="http://0.0.0.0:5000"
root@9ca5901163a9:/app# dotnet Ejemplo_03_CRUD_Simple_Login.dll




Ejemplo01CRUDSimpleDB.mssql.somee.com

sqlcmd -S Ejemplo01CRUDSimpleDB.mssql.somee.com -U sa -P MSS-fernando-123

ping 172.17.0.2

sqlcmd -S 172.17.0.2 -U sa -P MSS-fernando-123


apt-get install -y mssql-tools 

pt-get install -y iputils-ping


/opt/mssql-tools18/bin/sqlcmd -S 172.17.0.2 -U sa -P 'MSS-fernando-123'


/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 'MSS-fernando-123' -i /src/sql_script/docker_script.sql -C


/opt/mssql-tools/bin/sqlcmd -S 172.17.0.2 -U sa -P 'MSS-fernando-123'  -C "Encrypt=False" 


habilitando acceso externo

Sqlcmd: Warning: The last operation was terminated because the user pressed CTRL+C
@fernandofilipuzzi-utn ➜ .../Ejemplo_ASP.NET_MVC6/Scripts/Ejemplo_03_CRUD_Simple_Login/docker (main) $ sqlcmd -S Server=ejemplo02_mssql_container,1433 -U sa -P MSS-fernando-123
lookup Server=ejemplo02_mssql_container: no such host
lookup Server=ejemplo02_mssql_container: no such host
@fernandofilipuzzi-utn ➜ .../Ejemplo_ASP.NET_MVC6/Scripts/Ejemplo_03_CRUD_Simple_Login/docker (main) $ ping Server=ejemplo02_mssql_container
bash: ping: command not found
@fernandofilipuzzi-utn ➜ .../Ejemplo_ASP.NET_MVC6/Scripts/Ejemplo_03_CRUD_Simple_Login/docker (main) $ docker ps
CONTAINER ID   IMAGE                         COMMAND                  CREATED          STATUS          PORTS                                       NAMES
337751874f7b   ejemplo03_dotnet_image:v0.1   "dotnet Ejemplo_03_C…"   17 minutes ago   Up 17 minutes   0.0.0.0:8080->8080/tcp, :::8080->8080/tcp   ejemplo03_dotnet_container
b2811b10478b   ejemplo02_mssql:v0.1          "/opt/mssql/bin/sqls…"   3 hours ago      Up 3 hours      0.0.0.0:1433->1433/tcp, :::1433->1433/tcp   ejemplo02_mssql_container
@fernandofilipuzzi-utn ➜ .../Ejemplo_ASP.NET_MVC6/Scripts/Ejemplo_03_CRUD_Simple_Login/docker (main) $ ping ejemplo02_mssql_containe
bash: ping: command not found
@fernandofilipuzzi-utn ➜ .../Ejemplo_ASP.NET_MVC6/Scripts/Ejemplo_03_CRUD_Simple_Login/docker (main) $ docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' ejemplo02_mssql_container
172.17.0.2
@fernandofilipuzzi-utn ➜ .../Ejemplo_ASP.NET_MVC6/Scripts/Ejemplo_03_CRUD_Simple_Login/docker (main) $ ping 172.17.0.2
bash: ping: command not found
@fernandofilipuzzi-utn ➜ .../Ejemplo_ASP.NET_MVC6/Scripts/Ejemplo_03_CRUD_Simple_Login/docker (main) $ sqlcmd -S Server=172.17.0.2,1433 -U sa -P MSS-fernando-123
lookup Server=172.17.0.2: no such host
lookup Server=172.17.0.2: no such host
@fernandofilipuzzi-utn ➜ .../Ejemplo_ASP.NET_MVC6/Scripts/Ejemplo_03_CRUD_Simple_Login/docker (main) $ docker exec -it ejemplo02_mssql_container bash
root@b2811b10478b:/src/ej02# cd /var/opt/mssql/
root@b2811b10478b:/var/opt/mssql# sudo nano /var/opt/mssql/mssql.conf
bash: sudo: command not found
root@b2811b10478b:/var/opt/mssql# ls
data  log  secrets
root@b2811b10478b:/var/opt/mssql# /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P MSS-fernando-123
1> EXEC sp_configure 'show advanced options', 1;
2> NFIGURE;
3> go
Msg 102, Level 15, State 1, Server b2811b10478b, Line 2
Incorrect syntax near 'NFIGURE'.
1> EXEC sp_configure 'show advanced options', 1;
2> RECONFIGURE;
3> EXEC sp_configure 'remote access';
4> go
Configuration option 'show advanced options' changed from 0 to 1. Run the RECONFIGURE statement to install.
name                                minimum     maximum     config_value run_value  
----------------------------------- ----------- ----------- ------------ -----------
remote access                                 0           1            1           1
1> EXEC sp_configure 'remote access', 1;
2> RECONFIGURE;
3> go
Configuration option 'remote access' changed from 1 to 1. Run the RECONFIGURE statement to install.
1>      EXEC sp_configure 'remote access';
2> go
name                                minimum     maximum     config_value run_value  
----------------------------------- ----------- ----------- ------------ -----------
remote access                                 0           1            1           1
1> /opt/mssql/bin/sqlservr &
2> exit
root@b2811b10478b:/var/opt/mssql# /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 'MSS-fernando-123' -i /src/ej02/script.sql
Changed database context to 'master'.
Changed database context to 'EjemploCRUDSimpleLoginDB'.

(3 rows affected)
root@b2811b10478b:/var/opt/mssql# /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 'MSS-fernando-123' 
1> select * from personas
2> go
Msg 208, Level 16, State 1, Server b2811b10478b, Line 1
Invalid object name 'personas'.
1> exit
root@b2811b10478b:/var/opt/mssql# sqlcmd -S 172.17.0.2 -U sa -P MSS-fernando-123
bash: sqlcmd: command not found
root@b2811b10478b:/var/opt/mssql# exit
exit
@fernandofilipuzzi-utn ➜ .../Ejemplo_ASP.NET_MVC6/Scripts/Ejemplo_03_CRUD_Simple_Login/docker (main) $ sqlcmd -S 172.17.0.2 -U sa -P MSS-fernando-123
1> select * from personas
2> go
Msg 208, Level 16, State 1, Server b2811b10478b, Line 1
Invalid object name 'personas'.
1> use EjemploCRUDSimpleLoginDB
2> go
Changed database context to 'EjemploCRUDSimpleLoginDB'.
1> select * from personas
2> go
Id          DNI         Nombre                                                                                               Fecha_Nacimiento
----------- ----------- ---------------------------------------------------------------------------------------------------- ----------------
          1   353432432 Sebastian                                                                                                  1990-01-01
          2    35327489 Esteban                                                                                                    1990-01-01
          3    43323432 Luisa                                                                                                      2000-01-01

(3 rows affected)
1> 