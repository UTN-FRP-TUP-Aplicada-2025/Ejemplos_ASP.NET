#!/bin/bash

TAG='v0.1'

NOMBRE_IMAGEN='ejemplo01_mssql_image'
NOMBRE_CONTENEDOR='ejemplo01_mssql_container'
SOLUCION_PATH='/workspaces/Ejemplos_ASP.NET_MVC6/Ejemplo_ASP.NET_MVC6/'


# paro el contenedor - por si esta corriendo
docker stop $NOMBRE_CONTENEDOR

# borro el contenedor por si ya estaba
docker rm $NOMBRE_CONTENEDOR

# borro la imagen
docker rmi $NOMBRE_IMAGEN:$TAG

# construyo la imagen
docker build --no-cache -f Dockerfile.mssql -t $NOMBRE_IMAGEN:$TAG $SOLUCION_PATH


# genero el contenedor y lo corro
docker run --name $NOMBRE_CONTENEDOR -p 1433:1433 -d $NOMBRE_IMAGEN:$TAG

# listo los contenedores corriendo
docker ps 

# observo el status del contenedor
docker logs $NOMBRE_CONTENEDOR


#IP_CONTENEDOR=docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' $NOMBRE_CONTENEDOR

# configurando la base de datos

#docker exec -it $NOMBRE_CONTENEDOR /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 'MSS-fernando-123' -i /src/sql_script/docker_script.sql
#/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 'MSS-fernando-123' -i /src/sql_script/docker_script.sql -C

# espero hasta levante el contenedor
sleep 20

docker exec -it $NOMBRE_CONTENEDOR /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 'MSS-fernando-123' -i /src/sql_script/docker_script.sql -C

#docker exec -it ejemplo03_mssql_container /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 'MSS-fernando-123' -i /src/sql_script/docker_script.sql -C
