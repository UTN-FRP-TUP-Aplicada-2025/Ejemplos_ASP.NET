#!/bin/bash

TAG='v0.1'
NOMBRE_IMAGEN='ejemplo02_dotnet_image'
NOMBRE_CONTENEDOR='ejemplo02_dotnet_container'
SOLUCION_PATH='/workspaces/Ejemplos_ASP.NET_MVC6/Ejemplo_ASP.NET_MVC6/'

# limpia imagenes no usadas , contenedores detenidos y volúmenes
docker system prune -a

# borro la imagen
docker rmi ejemplo02_dotnet_image:$TAG

# construyo la imagen
docker build  --no-cache -f Dockerfile.dotnet -t $NOMBRE_IMAGEN:$TAG $SOLUCION_PATH

# paro el contenedor - por si esta corriendo
docker stop $NOMBRE_CONTENEDOR

# borro el contenedor por si ya estaba
docker rm $NOMBRE_CONTENEDOR

# genero el contenedor y lo corro
docker run --name $NOMBRE_CONTENEDOR -p 8080:8080 -d $NOMBRE_IMAGEN:$TAG

# listo los contenedores corriendo
docker ps 

# observo el status del contenedor
docker logs $NOMBRE_CONTENEDOR