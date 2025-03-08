#!/bin/bash

# para el contenedor, construye la imagen, y crea y corre el contenedor

TAG='v0.1'

NOMBRE_IMAGEN='ejemplo_asp_net_image'
NOMBRE_CONTENEDOR='ejemplo_asp_net_container'
DOCKER_FILE='/workspaces/Ejemplos_ASP.NET/Ejemplos_ASP.NET/CONTENEDORES/dockerfiles/Dockerfile.dotnet'
SOLUCION_PATH='/'

# paro el contenedor - por si esta corriendo
# borro el contenedor por si ya estaba
docker stop $NOMBRE_CONTENEDOR 2>/dev/null && docker rm $NOMBRE_CONTENEDOR 2>/dev/null

# borro la imagen
if docker images | grep -q "$NOMBRE_IMAGEN.*$TAG"; then
  docker rmi $NOMBRE_IMAGEN:$TAG
fi

# construyo la imagen
docker build --no-cache -f $DOCKER_FILE -t $NOMBRE_IMAGEN:$TAG $SOLUCION_PATH | tee build.log

# genero el contenedor y lo corro
# restart always permite el reinicio automatico
docker run --restart always --name $NOMBRE_CONTENEDOR -p 8082:8082 -d $NOMBRE_IMAGEN:$TAG

# listo los contenedores corriendo
docker ps 

# observo el status del contenedor
docker logs ejemplo_asp_net_container

# docker run -it ejemplo_asp_net_container /bin/bash


# docker restart $NOMBRE_CONTENEDOR

# Conexion desde el host
#docker exec -it ejemplo_asp_net_container /bin/bash
#docker run --rm -it ejemplo_asp_net_container /bin/sh
# docker logs --tail=100 -f ejemplo_asp_net_container

# entrar en forma interativa cuando no lo lanza
#docker run -it --entrypoint /bin/bash ejemplo_asp_net_image:v0.1