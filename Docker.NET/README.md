
- Link do projeto no DockerHub:
https://hub.docker.com/r/tiagoribeirog/webapp-mvc_dotnet-core2_mysql

## Índice
1- Introdução

2- Lista de comandos utilizados

3- Instalando Docker e executando um container MySQL

4- Compilando projeto em imagem docker e enviando ao Docker Hub

5- Katacoda (Extra)

## 1- Introdução
Este repositório tem como objetivo demonstrar da forma mais direta e com o menor número de passos possíveis como executar um container utilizando o MySQL. Posteriormente, como compilar um projeto .NET Core e enviá-lo ao DockerHub.

O projeto encontrado neste repositório é um CRUD de exemplo simples e funcional publicado no Docker Hub (link acima).

## 2- Lista de comandos utilizados
```
$ docker images # Lista todas as imagens iniciados no computador
$ docker ps -a # Listar todos os container iniciados e portas em uso
$ docker rm -f CONTAINER_ID # remove o container
$ docker rmi IMAGEM_ID # remove a imagem docker (certifique-se que ela não está executando como um container antes de removê-la)
$ docker build -f “dockerfile” . # Compila o projeto em uma imagem docker
$ docker-compose up # Inicia a imagem em um container
$ docker commit # Commit do projeto 
$ docker push # Enviar projeto para repositório remoto
```
## 3- Instalando Docker e executando um container MySQL

No ambiente windows, faça download do Docker Desktop:
[https://hub.docker.com/?overlay=onboarding](https://hub.docker.com/?overlay=onboarding)

Crie uma pasta e dentro dela, execute: 

```$ docker run --name amazingdb -e MYSQL_ROOT_PASSWORD=123456 -e MYSQL_DATABASE=amazingdb -p 3306:3306 -d mysql```

Aqui você irá fazer pull da imagem automaticamente e executar o container criando um banco de dados de nome "amazingdb", usuário "root", senha "123456" pela porta 3306

Para testar, tente acessar o MySQL pelo CMD, PhpMyAdmin, Workbench (da forma que você achar mais adequado), você terá que ter sucesso.

Para remover o container, execute:

1- ``` $ docker ps -a ``` para listar todos os containers em execução e copie o CONTAINER_ID

2- ``` $ docker rm -f CONTAINER_ID ``` cole o CONTAINER_ID copiado anteriormente no local informado

Para remover a imagem, execução:

1- ``` $ docker images ``` Lista todas as imagens e copie a IMAGEM_ID

2- ``` $ docker rmi IMAGEM_ID ``` cole a IMAGEM_ID copiada anteriormente no local informado

## 4- Compilando projeto em imagem docker e enviando ao Docker Hub

Com o prompt de preferência, acesse a pasta do projeto .net onde está localizado o arquivo "dockerfile" e execute: 

```$ docker build -f “dockerfile” .```

Execute:

```$ docker images```

Da lista de imagens, copie o "IMAGE ID" do projeto compilado.

Cole a imagem no arquivo docker-compose.yml do projeto em image:

Ex.: ``` image: 305657a89deb ```  (image é a linha no docker-compose.yml, a numeração é o IMAGE ID)

Na pasta onde encontra-se o docker-compose.yml, execute:

``` $ docker-compose up ```

Execute:

``` $ docker ps -a ``` 

Copie o “CONTAINER ID” do projeto.

Faça o "commit" do mesmo informando o CONTAINER ID, diretório no docker hub e dê uma tag para ficar "bonitinho ^^" ficando assim: 

``` 
$ docker commit container_id seu_usuario_docker_hub/repositorio_docker_hub:tag 

Ex.:
$ docker commit a478f7a1c733 tiago/webapp_dotnet:1.0.0
``` 
Para enviar ao Docker Hub, escreva:

```
$ docker push seu_usuario_docker_hub/repositorio_docker_hub:tag

Ex.:
$ docker push tiago/webapp_dotnet:1.0.0
```

## 5- Katacoda (Extra)

- https://www.katacoda.com/
Caso você não consiga ou não queira utilizar o Docker em seu computador, você pode simular o ambiente pelo Katacoda.
