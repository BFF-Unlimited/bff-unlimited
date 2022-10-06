# BFF Unlimited

A proof of concept of the landing page of 'ESIS Nieuw'.

## Getting started

```sh
git clone https://github.com/BFF-Unlimited/bff-unlimited.git
```

### Development env

#### Docker
*Nothing*

#### Setup visualstudeo
*Nothing*

#### Setup visualstudeo code
*Install the folowing add-ins:*
- C#

Welcome to the C# extension for Visual Studio Code! This extension provides the following features inside VS Code:
Lightweight development tools for .NET Core.
Great C# editing support, including Syntax Highlighting, IntelliSense, Go to Definition, Find All References, etc.
Debugging support for .NET Core (CoreCLR). NOTE: Mono debugging is not supported. Desktop CLR debugging has limited support.
Support for project.json and csproj projects on Windows, macOS and Linux.
- EditorConfig for VS code

For code formating
- CSharpier - Code formatter (Optional) 

Adds shortcuts and format on save
- NuGet Package Manager
- Prettier - Code formatter

Prettier is an opinionated code formatter. It enforces a consistent style by parsing your code and re-printing it with its own rules that take the maximum line length into account, wrapping code when necessary.
- Vue 3 Snippets (Optional)

This extension adds Vue 2 Snippets and Vue 3 Snippets into Visual Studio Code.
- Vue Language Features (Volar)

Vue Language Features is a language support extension built for Vue, Vitepress and petite-vue. this is based on @vue/reactivity to calculate everything on-demand, to implement native TypeScript language service level performance.

*Configuration:*
Open the settings in VSCode and search for Omnisharp. 
Than you need to "Enable Editor Config Support" and to "Enable Roslyn Analyzers"

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

When there are changes to the project, then a new build (image) must be created. This can be done with the command: 

```sh
    docker-compose up --build --force-recreate -d 
```

or

```sh
    docker-compose up --build -d
```

Caveats: 
* Developing frontend means turning off the bff_unlimited_client container.
* Developing backend means turning off the bff_unlimited_client container.
* When the code for frontend and backend is complete. Then you can use the `docker-compose up --build -d` to view the full result of both frontend and backend. Only needs to be done when developing is finished.

Om Docker containers te kunnen pullen vanuit de privéregistry van Rovict, kun je de volgende commands gebruiken:
```sh
az login
az acr login -n rovict
```

## Other scripts
`npm run ...` | Description
---|---
`storybook` | Starts the Storybook server on [`http://localhost:6006`](http://localhost:6006)

## Style guide
Taal | Url
---|---
C#|https://bff-ultemate.atlassian.net/wiki/spaces/BFFUNLIMIT/pages/622593/C%23+coding+style+guide?atlOrigin=eyJpIjoiZTZmZmVmMTMzYzNhNGQ1Y2E3NTU1Mjc0ZTBkMjBmYTUiLCJwIjoiaiJ9
