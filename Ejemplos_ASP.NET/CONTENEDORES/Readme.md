
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


## Limpieza! -  borrando contenedores detenidas e imagenes no utilizadas

```bash
docker container prune
docker image prune -a
docker network prune
```

borra hasta la cache
```
docker system prune -a --volumes
docker system prune --all --force
```



### Referencias

[Resumen de comandos docker](https://docs.google.com/document/d/12oavJniiUoNuO1E_vE3pisjdlw7A-7wu/preview)



## DockerHub 

### login 

```bash
docker login -u fernandofilipuzzidev -p clave ***
```

### Baja la imagen del repositorio
```bash
docker pull <nombre-del-repositorio>/<nombre-de-la-imagen>:<etiqueta>
```

### Sube la imagen al repositorio
```bash
docker push <nombre-del-repositorio>/<nombre-de-la-imagen>:<etiqueta>
```
--all-tags empuja todas las etiquetas

## subir la imagen al repositorio


Ejemplo:
```bash
docker login -u fernandofilipuzzidev -p clave ***
```

crear el repositorio en dockerhub
https://hub.docker.com/repositories/fernandofilipuzzidev

```bash
docker tag ejemplo_asp_net_image:v0.1 fernandofilipuzzidev/ejemplo_asp_net:v0.1
docker push fernandofilipuzzidev/ejemplo_asp_net:v0.1
```

## bajar la imagen y crear el contenedor 

Ejemplo: 
```bash 
docker pull fernandofilipuzzidev/ejemplo_asp_net:v0.1
docker run --name ejemplo_asp_net_container -p 8082:8082 -d fernandofililipuzzidev/ejemplo_asp_net_image:v0.1
```




## Comandos de adminitración

### correr sql desde la terminal
```bash
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 'MSS-fernando-123' -i /src/ej02/script.sql
```

```
sqlcmd -S Server=172.17.0.2,1433 -U sa -P MSS-fernando-123 -C
```

```
/opt/mssql-tools/bin/sqlcmd -S 172.17.0.2 -U sa -P 'MSS-fernando-123'  -C "Encrypt=False" 
```

```
sqlcmd -S Server=ejemplo02_mssql_container,1433 -U sa -P MSS-fernando-123 -C
```

 /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P MSS-fernando-123


 habilitar remoto

1> EXEC sp_configure 'show advanced options', 1;
2> RECONFIGURE;
3> EXEC sp_configure 'remote access';
4> go


sqls

1> use EjemploCRUDSimpleLoginDB
2> go
Changed database context to 'EjemploCRUDSimpleLoginDB'.
1> select * from personas
2> go
Id          DNI         Nombre                                                                                               Fecha_Nacimiento
----------- ----------- ---------------------------------------------------------------------------------------------------- ----------------
          1   353432432 Sebastian                                                                                                  1990-01-01
          2    35327489 Esteban                                                                                                    1990-01-01
          3    43323432 Luisa                                                                                                      2000-01-01





