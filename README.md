# Ejemplos_ASP.NET_MVC6


docker image

## limpiando!

borrando contenedores detenidas e imagenes no utilizadas

```
docker container prune
docker image prune -a
docker network prune
```

borra hasta la cache
```
docker system prune -a --volumes
docker system prune --all --force
```

## optener la ip del contenedor

```
root@9ca5901163a9:/app# export ASPNETCORE_URLS="http://0.0.0.0:5000"
root@9ca5901163a9:/app# dotnet Ejemplo_03_CRUD_Simple_Login.dll
```


## optener la ip del contenedor

```
docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' ejemplo02_mssql_container
```
 
```
IP="$(docker inspect -f '{{range.NetworkSettings.Networks}}{{.IPAddress}}{{end}}' ejemplo03_dotnet_container)"
echo $IP
```

## administrar sql 

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



## contenedores

```
docker ps
```


## entrar en un contenedor

```
docker exec -it ejemplo02_mssql_container /bin/bash
```



1> 

ntpq -p
chronyc tracking



