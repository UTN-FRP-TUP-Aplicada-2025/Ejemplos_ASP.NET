
## Dockerfile

| Comando  | Descripción                                                    |
|----------|----------------------------------------------------------------|
|``COPY``  | Copia los archivos desde el host al contenedor                 |
|``ARG``   | variables solo visibles durante el proceso de construcción     |
|``ENV``   | variables disponibles en tiempo de ejecución                   |
|``RUN``   | ejecuta comandos durante la construcción de la imagen          |

 
### Referencias:
[Resumen de comandos docker file](https://docs.google.com/document/d/19iBZtqOpPS8-sLie3ezD2BSc3xpYNJ2w/preview)

## Imagenes

```bash
 docker build -f Dockerfile.dotnet -t name_image:v0.1 /path_proyecto
 ```

 Ejemplos

```bash
@fernandofilipuzzi-utn ➜ .../Ejemplo_ASP.NET_MVC6/Scripts/Ejemplo_CRUD_Simple_Login/docker (main) $ docker images -a
REPOSITORY         TAG       IMAGE ID       CREATED         SIZE
ejemplo02_dotnet   v0.1      63bc278019ac   3 minutes ago   283MB
```


## Contenedores

### listar
-a contenedores detenidos

```bash
docker ps
```

```bash
docker ps -aq
````

### Crear contenedor
```bash
docker run --name name_container -p 8080:8080 -d name_image:v0.1 
```

### ver logs
```bash
docker logs name_container
```

### Parar contenedor
```bash
docker stop name_container
```

### reset contenedor
```bash
docker restart name_container
```

### Abrir sesión interactivo
```bash
docker exec -it name_container /bin/bash
```

### Mostrar la ip del contenedor
```bash
docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' name_container
```
R:
```bash
172.17.0.2
```

## Comandos de adminitración

### correr sql desde la terminal
```bash
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 'MSS-fernando-123' -i /src/ej02/script.sql
```

### Referencias

[Resumen de comandos docker](https://docs.google.com/document/d/12oavJniiUoNuO1E_vE3pisjdlw7A-7wu/preview)







