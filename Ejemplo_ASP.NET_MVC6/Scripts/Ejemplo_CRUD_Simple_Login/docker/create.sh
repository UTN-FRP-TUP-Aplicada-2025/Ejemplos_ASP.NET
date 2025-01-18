#!/bin/bash

TAG='v0.1'
TAG_R='v0.1'

docker rmi ejemplo03_dotnet:$TAG_R

docker build -f Dockerfile.dotnet -t ejemplo03_dotnet:$TAG /workspaces/Ejemplos_ASP.NET_MVC6/Ejemplo_ASP.NET_MVC6/

docker stop ejemplo01_dotnet_container

docker rm ejemplo01_dotnet_container

docker run --name ejemplo01_dotnet_container -p 8080:8080 -d ejemplo01_dotnet:$TAG