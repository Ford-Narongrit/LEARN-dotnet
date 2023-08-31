# My First .NET Framework 6.0 for backend API

## Setup project

1. create appsettings.Development.json

  ```bash
  cp appsettings.json appsettings.Development.json
  ```

2. get google Oauth2 and edit appsettings.Development.json
3. run project

## Run project

- normal run

```bash
dotnet run
```

- run watch

```bash
dotnet watch run
```

## Getting started [Reference](https://jasonwatmore.com/post/2022/03/15/net-6-crud-api-example-and-tutorial#program-cs)

1. create project with webapi template

   ```bash
   dotnet new webapi -minial -n <project_name> -f net6.0
   ```

2. add package

   ```bash
   dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore

   dotnet add package Microsoft.EntityFrameworkCore.SqlServer

   dotnet add package Microsoft.EntityFrameworkCore.Design
   ```

3. run project
   ```bash
   dotnet run
   ```

## Folder structure

- Controller
  - APi
    - UserController.cs
- Entities
  - User.cs
- Helpers
  - AppException.cs
  - AutoMapperProfile.cs
  - DataContext.cs
  - ErrorHandlerMiddleware.cs
- Validators
  - User
    - CreateRequest.cs
    - UpdateRequest.cs
- Services
  - UserService.cs

## Migration

we can create migration file in 2 way.

1. we can do as auto migration with Entities models.
   ```bash
   dotnet ef migrations add InitialCreate
   ```
2. we can manual create
   ```bash
   dotnet ef migrations add <migration_file>
   ```

run migrate

```bash
dotnet ef database update
```

## Run with Docker

- run

  ```bash
  docker-compose up -d
  ```

- use command
  ```bash
  docker-compose exec -it dotnetapp <command>
  ```
