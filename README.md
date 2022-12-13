# TaskTracker

# To run application
- In order to start Application Connection String should be configured!
- Dependencies indicated below (section "Technologies used") should be installed
- Restore migrations

# Technologies used:
- Microsoft.EntityFrameworkCore 6.0.10;
- Microsoft.EntityFrameworkCore.Tools 6.0.10;
- Microsoft.EntityFrameworkCore.Design 6.0.10;
- Npgsql.EntityFrameworkCore.PostgreSQL 6.0.7;
- Swashbuckle.AspNetCore 6.2.3;
- Swashbuckle.AspNetCore.Swagger 6.2.3;
- Swashbuckle.AspNetCore.SwaggerGen 6.2.3;
- Swashbuckle.AspNetCore.SwaggerUI 6.2.3;

# Migrations:
1. To add migration use command: dotnet ef migrations add [name]
2. Update DataBase: dotnet ef database update

Use the following command in terminal for working with migrations: 

```

dotnet tool install --global dotnet-ef --version 6.*

```

For some reason terminal didn't recognise "dotnet ef" command even with MS EF Tools installed.
