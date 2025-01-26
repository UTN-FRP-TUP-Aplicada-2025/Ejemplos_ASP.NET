


## contenedor asp.net

Referencias
[Resumen de comandos docker](https://docs.google.com/document/d/12oavJniiUoNuO1E_vE3pisjdlw7A-7wu/preview)

1- Crear el dockerfile

```
```


2- Construir la imagen

```bash
 docker build -f Dockerfile.dotnet -t ejemplo02_dotnet:v0.5 /workspaces/Ejemplos_ASP.NET_MVC6/Ejemplo_ASP.NET_MVC6/
```

3- consultar imagenes creadas

```bash
docker ps -aq
````

Ejemplos

```bash
@fernandofilipuzzi-utn ➜ .../Ejemplo_ASP.NET_MVC6/Scripts/Ejemplo_CRUD_Simple_Login/docker (main) $ docker images -a
REPOSITORY         TAG       IMAGE ID       CREATED         SIZE
ejemplo02_dotnet   v0.1      63bc278019ac   3 minutes ago   283MB
```


4- crear el contenedor

```bash
docker run --name ejemplo02_dotnet_container -p 8080:8080 -d ejemplo02_dotnet:v0.5 
```


ver que paso con el contenedor

```
@fernandofilipuzzi-utn ➜ .../Ejemplo_ASP.NET_MVC6/Scripts/Ejemplo_CRUD_Simple_Login/docker (main) $ docker logs ejemplo02_dotnet_container
The command could not be loaded, possibly because:
  * You intended to execute a .NET application:
      The application 'webapiNetCore.dll' does not exist.
  * You intended to execute a .NET SDK command:
      No .NET SDKs were found.

Download a .NET SDK:
https://aka.ms/dotnet/download

Learn about SDK resolution:
https://aka.ms/dotnet/sdk-not-found
```


## contenedor mssql

```bash
 docker build -f Dockerfile.mssql -t ejemplo02_mssql:v0.1 /workspaces/Ejemplos_ASP.NET_MVC6/Ejemplo_ASP.NET_MVC6/Scripts/Ejemplo_CRUD_Simple_Login/
```

reviso las imagenes

```bash
 docker images -a
```

```bash
docker run --name ejemplo02_mssql_container -p 1433:1433 -d ejemplo02_mssql:v0.1 
```

--latest

reviso los contenedores corriendo

```bash
docker ps
```

```
docker exec -it ejemplo02_mssql_container /bin/bash
```


/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 'MSS-fernando-123' -i /src/ej02/script.sql

@fernandofilipuzzi-utn ➜ .../Ejemplo_ASP.NET_MVC6/Scripts/Ejemplo_CRUD_Simple_Login/docker (main) $ docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' ejemplo02_mssql_container
172.17.0.2

