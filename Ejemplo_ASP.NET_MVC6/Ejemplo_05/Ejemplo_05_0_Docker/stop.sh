#!/bin/bash

TAG='v0.1'
NOMBRE_IMAGEN='ejemplo05_dotnet_image'
NOMBRE_CONTENEDOR='ejemplo05_dotnet_container'
SOLUCION_PATH='/workspaces/Ejemplos_ASP.NET_MVC6/Ejemplo_ASP.NET_MVC6/'


# paro el contenedor - por si esta corriendo
docker stop $NOMBRE_CONTENEDOR

