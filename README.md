# SpotyfiApi

The SpotifyApi is a proyect is a project written in c#, the project aims to meet the challenge for a candidate for backend developer, in Patagonian company, to carry out the project, the following are taken into account:

    - clean architecture
    - Dependency injection
    - Entity Framework Core
    - Fluent Api
    - DTOs & Automapper
    - Business Logic and Repository Pattern
    - Unit of Work 
    - Custom Exceptions
    - Pagination

### Project structure

The project is structured as follows:

##### 1. SpotifyApi(solution project):
- contains all projects
##### 2. SpotifyApi.Api(expose api rest): 
- contains the controls that expose the api, and contains all the project configurations.
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
- contains all implementations, definition of entities, abstractions, implementation of use cases, applying dependency injection.
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

##### 4. SpotifyApi.Utilities(project commun utilities): 
- Contains files of common utilities, constants, functions.
##### Platforms
- NetStandard:Library(2.1.0)
##### NuGet
- Newtonsoft.Json(12.0.3)