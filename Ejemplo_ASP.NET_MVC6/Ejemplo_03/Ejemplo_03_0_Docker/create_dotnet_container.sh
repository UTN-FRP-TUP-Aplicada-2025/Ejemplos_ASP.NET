#!/bin/bash

TAG='v0.1'
NOMBRE_IMAGEN='ejemplo03_dotnet_image'
NOMBRE_CONTENEDOR='ejemplo03_dotnet_container'
SOLUCION_PATH='/workspaces/Ejemplos_ASP.NET_MVC6/Ejemplo_ASP.NET_MVC6/'

# paro el contenedor - por si esta corriendo
docker stop $NOMBRE_CONTENEDOR

# borro el contenedor por si ya estaba
docker rm $NOMBRE_CONTENEDOR

# borro la imagen
docker rmi $NOMBRE_IMAGEN:$TAG

# construyo la imagen
docker build --no-cache -f Dockerfile.dotnet -t $NOMBRE_IMAGEN:$TAG $SOLUCION_PATH

# genero el contenedor y lo corro
docker run --name $NOMBRE_CONTENEDOR -p 8080:80 -d $NOMBRE_IMAGEN:$TAG

# listo los contenedores corriendo
docker ps 

# observo el status del contenedor
docker logs $NOMBRE_CONTENEDOR

# docker restart $NOMBRE_CONTENEDOR