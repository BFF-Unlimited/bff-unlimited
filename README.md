# BFF Unlimited

A proof of concept of the landing page of 'ESIS Nieuw'.

## Getting started

```sh
git clone https://github.com/BFF-Unlimited/bff-unlimited.git
```

### Server

```sh
cd bff-unlimited/server
dotnet restore
dotnet run --project Bff.WebApi\\Bff.WebApi.csproj
open browser naar: https://localhost:7182/swagger/index.html
```

### Client

The front-end requires [Node.js](http://nodejs.org/) and [npm](https://npmjs.org/) (comes with Node).

```sh
cd bff-unlimited/client
npm i
```

After installing dependencies using `npm install` run

```sh
npm run dev
```

to serve the app on [`http://localhost:3000`](http://localhost:3000).

## Docker enviroment
There are two ways to setup the docker environment with the DB, client and server available.
1. Run Start docker setup
2. Docker compose

The first sets up the whole docker environment with the needed SSl certification, client, server and DB. 
This must be exectud after cloning the repo.

The second setup can be executed after the first setup has been executed at least once (because of the required certificate).

### Run Start docker setup
The following command can be executed with powershell: 

```sh
    Start_docker_setup.bat
```

### Docker compose
The following command can be executed with powershell: 

```sh
    docker compose up -d
```

## Other scripts
`npm run ...` | Description
---|---
`storybook` | Starts the Storybook server on [`http://localhost:6006`](http://localhost:6006)


