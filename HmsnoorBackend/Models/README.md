# Scaffolding Models from existing database

- Install required nuget packages
  - cd into project directory where .csprj file exist.

    ``` sh
    cd [myapp]
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    dotnet add package Microsoft.EntityFrameworkCore.Tool
    dotnet add package Microsoft.EntityFrameworkCore.Design
    ```

- Connection String

    ```ini
    Server=127.0.0.1,1433;Database=[DbName];User Id=[username];Password=[password];Encrypt=False;TrustServerCertificate=True;"
    ```

- Run Scaffold

    ```sh
    dotnet ef dbcontext scaffold "Server=127.0.0.1,1433;Database=[DbName];User Id=[username];Password=[password];Encrypt=False;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c [MyAppDbContext]
    ```
