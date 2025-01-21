


## conocer la ip del mmsql container

```bash
docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' ejemplo04_mssql_container
```
--172.17.0.3