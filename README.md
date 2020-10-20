# SpotyfiApi

The SpotifyApi is a project written in c#, the project aims to meet the challenge for a candidate for backend developer in Patagonian company, to carry out the project, the following must be taken into account:

    - Clean architecture
    - Dependency injection
    - Entity Framework Corec
    - Fluent Api
    - DTOs & Automapper
    - Business Logic and Repository Pattern
    - Unit of Work
    - Custom Exceptions
    - Pagination

### Project structure

The project is structured as follows:

##### 1. SpotifyApi (solution project):
- Contains all projects
##### 2. SpotifyApi.Api(expose api rest):
- Contains the controls that expose the api, and contains all the project configurations.
##### Platforms
- Microsoft.AspNetCore.App(3.1.8)
- Microsoft:NetCore.App(3.1.0)
##### NuGet
- AutoMapper.Extensions.Microsoft.DependencyInjection(8.1.0)
- FluentValidation.AspNetCore(8.6.3)
- Microsoft.AspNetCore.Mvc.NewtonSoftJson(3.1.9)
- Microsoft.EntityFrameworkCore.Design(3.1.9)
- Microsoft.VisualStudio.Web.CodeGeneration.Design(3.1.4)
##### Projects
- SpotifyApi.Core
- SpotifyApi.Insfrastructure

##### 3. SpotifyApi.Core(business logic):
- Contains all implementations, definition of entities, abstractions, implementation of use cases, applying dependency injection.
##### Platforms
- NetStandard:Library(2.1.0)
##### NuGet
- Microsoft.Extensions.Options(3.1.9)
##### Projects
- SpotifyApi.Utilities

##### 4. SpotifyApi.Infrastructure(data processing):
- It contains all the data management of the application, implementations, own of the database and the Spotify api
##### Platforms
- NetStandard:Library(2.1.0)
##### NuGet
- AutoMapper.Extensions.Microsoft.DependencyInjection(8.1.0)
- FluentValidation.AspNetCore(8.6.3)
- Microsoft.AspNetCore.Mvc.Core(2.2.5)
- Microsoft.EntityFrameworkCore(3.1.9)
- Microsoft.EntityFrameworkCore.SqlServer(3.1.9)
- Microsoft.EntityFrameworkCore.Tools(3.1.9)
- RestSharp(106.11.7)

##### 5. SpotifyApi.Utilities(project commun utilities):
- Contains files of common utilities, constants, functions.
##### Platforms
- NetStandard:Library(2.1.0)
##### NuGet
- Newtonsoft.Json(12.0.3)

### Install environment( container, database image, api server )

To install the environment you must follow the following steps
- Download and install [Docker](https://www.docker.com/products/docker-desktop)
- Download the source code of **SpotifyApi**
- In the root directory you will find the following folders:
    1. **SpotifyApi**: Folder with the solution the api projects.
    2. **Database**: Folder with file.sql to database api.
    3. **ApiSpecification**: Folder with files api specification **(api.html, api.raml)**
- After installing Docker, go to the terminal and enter the directory **SpotifyApi**
    ```sh
    $ cd SpotifyApi/
    ```
- Once inside the directory **SpotifyApi**, run the command
    ```sh
    $ docker-compose up --build
    ```
- The container with the database image will be installed, and the application server on which the SpotifyApi solution will be published will be installed.
- You can test that it has been published by accessing the test endpoint **[weatherforecast](http://localhost/weatherforecast)**
- Will display the message
    ```
    Welcome to the Patagonian Test Api
    ```

### Install environment( create database )

To be able to make the connection and the creation of the database, we must perform the following steps:

- Download a database client SqlServer for example **[Azure Data Studio](https://docs.microsoft.com/en-us/sql/azure-data-studio/download-azure-data-studio?view=sql-server-ver15)**
- Go to connections and select new connection
- In the segment Connections details, register data connection
    ```sh
    Connection Type: Microsoft SQL Server
    Server: localhost
    Authentication type: SQL Login
    User name: sa
    Password: A_1234567O
    Database: <Default>
    Server group: <Default>
    Name (optional): Any Name
    ```
- Click on the connect option
- Once the database server is created, we proceed to create the database
- Let's go to the directory **Database** open the file **[Script.sql](Database/Script.sql)**
- In the client SqlServer open a **new query tab** and paste the sentence to create database
    ```sh
    CREATE DATABASE ApiSpotify;
    ```
- After creating the database, you can copy and paste all the remaining content of the file, and proceed to execute it.

**With this we conclude the installation of the environment**

### Consume Api

To consume the api you must follow the endpoints in the file **[api.html](ApiSpecification/api.html)**

**[Base Url](http://localhost/api)**:
```sh
http://localhost/api
```

Project created by **[Johnatan Alexis Urbano Guzmán](https://www.johnatan.dev/)**