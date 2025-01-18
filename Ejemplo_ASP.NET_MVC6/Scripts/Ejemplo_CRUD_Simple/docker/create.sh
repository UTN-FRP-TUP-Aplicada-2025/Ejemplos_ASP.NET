#!/bin/bash

TAG='v0.1'
TAG_R='v0.1'

docker rmi ejemplo02_dotnet:$TAG_R

docker build -f Dockerfile.dotnet -t ejemplo02_dotnet:$TAG /workspaces/Ejemplos_ASP.NET_MVC6/Ejemplo_ASP.NET_MVC6/

docker stop ejemplo02_dotnet_container

docker rm ejemplo02_dotnet_container

docker run --name ejemplo02_dotnet_container -p 8080:8080 -d ejemplo02_dotnet:$TAG