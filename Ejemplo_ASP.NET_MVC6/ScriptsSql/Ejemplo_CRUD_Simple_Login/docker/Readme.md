# tup_aplicada_2024_apiweb


## 

```
docker ps
```

## construir la imagen

le pongo un nombre random a la imagen

```
docker build -t webapi .
docker images
```

## ejecuta el contenedor

```
docker run -d -p 8080:80 webapi:latest
docker ps
```

## lista todas las imagenes
docker images -q

docker stop $(docker images -q)
docker rmi -f $(docker images -q)

Ejemplo

```
@fernandofilipuzzi-dev ➜ /workspaces/tup_aplicada_2024_apiweb (main) $ docker build -t webapi .
[+] Building 34.0s (16/16) FINISHED                                                                                                                                              docker:default
 => [internal] load build definition from Dockerfile                                                                                                                                       0.0s
 => => transferring dockerfile: 915B                                                                                                                                                       0.0s
 => [internal] load metadata for mcr.microsoft.com/dotnet/aspnet:8.0                                                                                                                       0.2s
 => [internal] load metadata for mcr.microsoft.com/dotnet/sdk:8.0                                                                                                                          0.2s
 => [internal] load .dockerignore                                                                                                                                                          0.0s
 => => transferring context: 2B                                                                                                                                                            0.0s
 => [build 1/7] FROM mcr.microsoft.com/dotnet/sdk:8.0@sha256:ff705b99a06144190e2638f8ede64a753915df5ea27fff55f58d0eb5f7054b0b                                                             22.2s
 => => resolve mcr.microsoft.com/dotnet/sdk:8.0@sha256:ff705b99a06144190e2638f8ede64a753915df5ea27fff55f58d0eb5f7054b0b                                                                    0.0s
 => => sha256:a7351312c5eaddafd358dcc39c678b48af370a233a700c3af22e993a0c5261cc 2.22kB / 2.22kB                                                                                             0.0s
 => => sha256:68abe8aaf35ac1c6421b1e107fa52de35bd4204b4d2f22b19b901f5420979116 18.72MB / 18.72MB                                                                                           0.4s
 => => sha256:1f15df2ada166b8a5c9d3bf529df6988b0d4dfd3b3b7e454a7f76a7a498668d2 3.28kB / 3.28kB                                                                                             0.0s
 => => sha256:5114c86b7dba956d0a8b8197c312f94761374adc25b46e587365f207fbb46156 32.24MB / 32.24MB                                                                                           1.1s
 => => sha256:ff705b99a06144190e2638f8ede64a753915df5ea27fff55f58d0eb5f7054b0b 1.08kB / 1.08kB                                                                                             0.0s
 => => sha256:3d4b35ceef0776af99609d3123b8b6d66df89be441d231d46373d3f9d40aa33e 5.67kB / 5.67kB                                                                                             0.0s
 => => sha256:302e3ee498053a7b5332ac79e8efebec16e900289fc1ecd1c754ce8fa047fcab 29.13MB / 29.13MB                                                                                           0.7s
 => => sha256:aafc33d0a31ed69849951fe7d08b81c08cf2e785151d4b567f235e65ad01e174 11.07MB / 11.07MB                                                                                           1.2s
 => => extracting sha256:302e3ee498053a7b5332ac79e8efebec16e900289fc1ecd1c754ce8fa047fcab                                                                                                  2.7s
 => => sha256:67ab521b24b9657140ba0aaee9ba512dbb4f0ae14d83e6b4b65766b700b7b607 174.16MB / 174.16MB                                                                                         4.6s
 => => sha256:bebb4f92cb8ee956cab0aed6e0617b4f2296d1c7d524c4f51c67d86319a885a2 155B / 155B                                                                                                 1.2s
 => => sha256:0887ff7a6c7126ad5aec950573ef14fb374ca3a1a9aecd4cbc7f020b6d1438ab 30.91MB / 30.91MB                                                                                           2.3s
 => => sha256:c3cb84754013698e3a36923b5cb6bd0f6f230d0dca44f62cb7444319e876f9d3 15.61MB / 15.61MB                                                                                           1.9s
 => => extracting sha256:68abe8aaf35ac1c6421b1e107fa52de35bd4204b4d2f22b19b901f5420979116                                                                                                  0.4s
 => => extracting sha256:1f15df2ada166b8a5c9d3bf529df6988b0d4dfd3b3b7e454a7f76a7a498668d2                                                                                                  0.0s
 => => extracting sha256:5114c86b7dba956d0a8b8197c312f94761374adc25b46e587365f207fbb46156                                                                                                  0.5s
 => => extracting sha256:bebb4f92cb8ee956cab0aed6e0617b4f2296d1c7d524c4f51c67d86319a885a2                                                                                                  0.0s
 => => extracting sha256:aafc33d0a31ed69849951fe7d08b81c08cf2e785151d4b567f235e65ad01e174                                                                                                  0.2s
 => => extracting sha256:0887ff7a6c7126ad5aec950573ef14fb374ca3a1a9aecd4cbc7f020b6d1438ab                                                                                                  1.2s
 => => extracting sha256:67ab521b24b9657140ba0aaee9ba512dbb4f0ae14d83e6b4b65766b700b7b607                                                                                                  4.4s
 => => extracting sha256:c3cb84754013698e3a36923b5cb6bd0f6f230d0dca44f62cb7444319e876f9d3                                                                                                  0.4s
 => [runtime 1/3] FROM mcr.microsoft.com/dotnet/aspnet:8.0@sha256:b3cdb99fb356091b6395f3444d355da8ae5d63572ba777bed95b65848d6e02be                                                         8.7s
 => => resolve mcr.microsoft.com/dotnet/aspnet:8.0@sha256:b3cdb99fb356091b6395f3444d355da8ae5d63572ba777bed95b65848d6e02be                                                                 0.0s
 => => sha256:302e3ee498053a7b5332ac79e8efebec16e900289fc1ecd1c754ce8fa047fcab 29.13MB / 29.13MB                                                                                           0.7s
 => => sha256:68abe8aaf35ac1c6421b1e107fa52de35bd4204b4d2f22b19b901f5420979116 18.72MB / 18.72MB                                                                                           0.4s
 => => sha256:1f15df2ada166b8a5c9d3bf529df6988b0d4dfd3b3b7e454a7f76a7a498668d2 3.28kB / 3.28kB                                                                                             0.0s
 => => sha256:5114c86b7dba956d0a8b8197c312f94761374adc25b46e587365f207fbb46156 32.24MB / 32.24MB                                                                                           1.1s
 => => sha256:b3cdb99fb356091b6395f3444d355da8ae5d63572ba777bed95b65848d6e02be 1.08kB / 1.08kB                                                                                             0.0s
 => => sha256:95ee01f3e36bc2d5e0872ab5e65572376161ae486b431a60404b5a8073c9a9bb 1.58kB / 1.58kB                                                                                             0.0s
 => => sha256:70975ed8a4039725cbe8b965b1af63119c2d115cf0c653177cf6a186863ebe9f 2.71kB / 2.71kB                                                                                             0.0s
 => => extracting sha256:302e3ee498053a7b5332ac79e8efebec16e900289fc1ecd1c754ce8fa047fcab                                                                                                 33.0s
 => => sha256:aafc33d0a31ed69849951fe7d08b81c08cf2e785151d4b567f235e65ad01e174 11.07MB / 11.07MB                                                                                          33.7s
 => => extracting sha256:5114c86b7dba956d0a8b8197c312f94761374adc25b46e587365f207fbb46156                                                                                                 27.0s
 => [internal] load build context                                                                                                                                                          0.0s
 => => transferring context: 694B                                                                                                                                                          0.0s
 => [runtime 2/3] WORKDIR /app                                                                                                                                                             0.1s
 => [build 2/7] WORKDIR /src                                                                                                                                                               0.0s
 => [build 3/7] COPY webapi/webapi.csproj ./webapi/                                                                                                                                        0.0s
 => [build 4/7] COPY webapi/. ./webapi/                                                                                                                                                    0.0s
 => [build 5/7] RUN dotnet restore ./webapi/webapi.csproj                                                                                                                                  3.3s
 => [build 6/7] RUN dotnet build ./webapi/webapi.csproj -c Release -o /app/build                                                                                                           4.7s
 => [build 7/7] RUN dotnet publish ./webapi/webapi.csproj -c Release -o /app/publish                                                                                                       2.3s
 => [runtime 3/3] COPY --from=build /app/publish .                                                                                                                                         0.1s
 => exporting to image                                                                                                                                                                     0.8s
 => => exporting layers                                                                                                                                                                    0.8s
 => => writing image sha256:2e995ba6d0d0f6df0300474e0920e4d9b64c42ccff041823e81053d977e27d2c                                                                                               0.0s
 => => naming to docker.io/library/webapi                                                                                                                                                  0.0s
@fernandofilipuzzi-dev ➜ /workspaces/tup_aplicada_2024_apiweb (main) $ docker ps
CONTAINER ID   IMAGE     COMMAND   CREATED   STATUS    PORTS     NAMES
@fernandofilipuzzi-dev ➜ /workspaces/tup_aplicada_2024_apiweb (main) $ docker run -d -p 8080:80 webapi
de6125ac1dbee502e68e9ab76d2c3eaf7349e210f167e39fc371281e8c1b0a32
@fernandofilipuzzi-dev ➜ /workspaces/tup_aplicada_2024_apiweb (main) $ docker ps
CONTAINER ID   IMAGE     COMMAND               CREATED              STATUS              PORTS                                   NAMES
de6125ac1dbe   webapi    "dotnet webapi.dll"   About a minute ago   Up About a minute   0.0.0.0:8080->80/tcp, :::8080->80/tcp   laughing_bhabha
```

abre una pagina 

https://obscure-giggle-g4pgx9gj7jj29x7x-8080.app.github.dev/


## quitar una imagen
```
@fernandofilipuzzi-dev ➜ /workspaces/tup_aplicada_2024_apiweb (main) $ docker ps
CONTAINER ID   IMAGE     COMMAND               CREATED              STATUS              PORTS                                             NAMES
ce39fdadf6be   webapi    "dotnet webapi.dll"   About a minute ago   Up About a minute   8080/tcp, 0.0.0.0:8080->80/tcp, :::8080->80/tcp   amazing_hopper

@fernandofilipuzzi-dev ➜ /workspaces/tup_aplicada_2024_apiweb (main) $ docker stop ce39fdadf6be
ce39fdadf6be

@fernandofilipuzzi-dev ➜ /workspaces/tup_aplicada_2024_apiweb (main) $ docker rm ce39fdadf6be
ce39fdadf6be

@fernandofilipuzzi-dev ➜ /workspaces/tup_aplicada_2024_apiweb (main) $ docker rmi webapi
Untagged: webapi:latest
Deleted: sha256:39040c3795cd74bbb4f91a533eaa9ad94d64a24085e44f1b3c6566f583cc9bca


@fernandofilipuzzi-dev ➜ /workspaces/tup_aplicada_2024_apiweb (main) $ docker images
REPOSITORY   TAG       IMAGE ID       CREATED          SIZE
<none>       <none>    2e995ba6d0d0   24 minutes ago   220MB
@fernandofilipuzzi-dev ➜ /workspaces/tup_aplicada_2024_apiweb (main) $ docker rmi 2e995ba6d0d0
Deleted: sha256:2e995ba6d0d0f6df0300474e0920e4d9b64c42ccff041823e81053d977e27d2c

```


localmente funciona.
```
@fernandofilipuzzi-dev ➜ /workspaces/tup_aplicada_2024_apiweb (main) $ curl http://localhost:8080/weatherforecast/
[{"date":"2024-10-13","temperatureC":8,"temperatureF":46,"summary":"Hot"},{"date":"2024-10-14","temperatureC":-2,"temperatureF":29,"summary":"Warm"},{"date":"2024-10-15","temperatureC":-6,"temperatureF":22,"summary":"Mild"},{"date":"2024-10-16","temperatureC":1,"temperatureF":33,"summary":"Chilly"},{"date":"2024-10-17","temperatureC":47,"temperatureF":116,"summary":"Cool"}]@fernandofilipuzzi-dev ➜ /workspaces/tup_aplicada_2024_apiweb (main) $ 
```

```
curl https://obscure-giggle-g4pgx9gj7jj29x7x.github.dev/weatherforecast/
```

en la parte inferniro, hay un icono torre, que es forwader port - pasarlo a public


# abre sessión interactiva con el navegador
```
docker exec -it cc10fe727e9f /bin/bash
```


#dockerhub

docker login


@fernandofilipuzzi-dev ➜ /workspaces/tup_aplicada_2024_apiweb (main) $ docker tag webapi:v1.6 fernandofilipuzzidev/webapi:v1.6
@fernandofilipuzzi-dev ➜ /workspaces/tup_aplicada_2024_apiweb (main) $ docker push fernandofilipuzzidev/webapi:v1.6
The push refers to repository [docker.io/fernandofilipuzzidev/webapi]
eb2140af9575: Pushed 
b533187a9d33: Pushed 
ea9d34e19430: Pushed 
f9b82ee3d2d8: Pushed 
eb516300731b: Pushed 
53d4df978da8: Pushed 
fbbd726292f0: Pushed 
8d853c8add5d: Pushed 
v1.6: digest: sha256:999450f8f0990d86816526552e5ffac0bebd270654837ad8a982ba72d1507a07 size: 1998
@fernandofilipuzzi-dev ➜ /workspaces/tup_aplicada_2024_apiweb (main) $ 