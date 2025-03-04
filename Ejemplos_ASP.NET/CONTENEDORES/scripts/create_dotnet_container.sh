#!/bin/bash

# para el contenedor, construye la imagen, y crea y corre el contenedor

TAG='v0.1'

NOMBRE_IMAGEN='ejemplo_asp_net_image'
NOMBRE_CONTENEDOR='ejemplo_asp_net_container'
PROYECTO_DIR='/workspaces/Ejemplos_ASP.NET/Ejemplos_ASP.NET/ASP.NET.MVC/Ejemplo_05/Ejemplo_05_0_Areas'
PROYECTO_FILE='/workspaces/Ejemplos_ASP.NET/Ejemplos_ASP.NET/ASP.NET.MVC/Ejemplo_05/Ejemplo_05_0_Areas/Ejemplo_05_Areas.csproj'
DOCKER_FILE='/workspaces/Ejemplos_ASP.NET/Ejemplos_ASP.NET/CONTENEDORES/dockerfiles/Dockerfile.dotnet'
SOLUCION_PATH='/'

# paro el contenedor - por si esta corriendo
#docker stop $NOMBRE_CONTENEDOR
# borro el contenedor por si ya estaba
#docker rm $NOMBRE_CONTENEDOR
docker stop $NOMBRE_CONTENEDOR 2>/dev/null && docker rm $NOMBRE_CONTENEDOR 2>/dev/null

# borro la imagen
if docker images | grep -q "$NOMBRE_IMAGEN.*$TAG"; then
  docker rmi $NOMBRE_IMAGEN:$TAG
fi

# construyo la imagen
docker build --no-cache -f $DOCKER_FILE -t $NOMBRE_IMAGEN:$TAG $SOLUCION_PATH | tee build.log

# genero el contenedor y lo corro
# restart always permite el reinicio automatico
docker run --restart always --name $NOMBRE_CONTENEDOR -p 8080:8080 -d $NOMBRE_IMAGEN:$TAG

# listo los contenedores corriendo
docker ps 

# observo el status del contenedor
docker logs ejemplo_asp_net_image

# docker restart $NOMBRE_CONTENEDOR

# Conexion desde el host
#docker exec -it ejemplo_asp_net_container /bin/bash
#docker run --rm -it ejemplo_asp_net_container /bin/sh