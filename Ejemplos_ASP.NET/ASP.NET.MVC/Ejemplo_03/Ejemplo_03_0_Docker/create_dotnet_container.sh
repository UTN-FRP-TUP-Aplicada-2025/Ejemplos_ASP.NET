#!/bin/bash

# para el contenedor, construye la imagen, y crea y corre el contenedor

TAG='v0.1'

NOMBRE_IMAGEN='ejemplo03_dotnet_image'
NOMBRE_CONTENEDOR='ejemplo03_dotnet_container'
EJEMPLO='Ejemplo_03'
DOCKER_FILE='Dockerfile.dotnet'
SOLUCION_PATH='/workspaces/Ejemplos_ASP.NET_MVC6/Ejemplo_ASP.NET_MVC6/'$EJEMPLO

# paro el contenedor - por si esta corriendo
docker stop $NOMBRE_CONTENEDOR

# borro el contenedor por si ya estaba
docker rm $NOMBRE_CONTENEDOR

# borro la imagen
docker rmi $NOMBRE_IMAGEN:$TAG

# construyo la imagen
docker build --no-cache -f $DOCKER_FILE -t $NOMBRE_IMAGEN:$TAG $SOLUCION_PATH

# genero el contenedor y lo corro
# restart always permite el reinicio automático
docker run --restart always --name $NOMBRE_CONTENEDOR -p 8080:8080 -d $NOMBRE_IMAGEN:$TAG

# listo los contenedores corriendo
docker ps 

# observo el status del contenedor
docker logs $NOMBRE_CONTENEDOR

# docker restart $NOMBRE_CONTENEDOR

# Conexión desde el host
#docker exec -it ejemplo03_dotnet_container /bin/bash