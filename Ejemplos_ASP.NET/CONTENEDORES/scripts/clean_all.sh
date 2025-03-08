#!/bin/bash

# detiene y elimina todos los contenedores
docker stop $(docker ps -aq) && docker rm $(docker ps -aq)

# elimina todas las imagenes
docker rmi -f $(docker images -q)

# elimina todos los volumenes
docker volume rm $(docker volume ls -q)

# elimina todas las redes no utilizadas
docker network prune -f

# elimina todo lo no no utilizado: contenedores, imágenes, volúmenes y redes 
docker system prune -a --volumes -f

# limpia recursos no utilizados. docker system prune
# -a          elimina imágenes sin referencia.
# --volumes   incluye volúmenes no utilizados.
# -f          borra TODO sin confirmación.
