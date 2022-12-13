# TaskTracker

This application allows to create "Projects" and related tasks ("ProjectTasks"). 
CRUD operations are available. 
Related end points can be traced with Swagger.
App is based on code first approach.

# Technologies used 
(all below frameworks, libraries and packages are publicly available):
- Microsoft.EntityFrameworkCore 6.0.10;
- PostgreSQL server;
- Microsoft.EntityFrameworkCore.Tools 6.0.10;
- Microsoft.EntityFrameworkCore.Design 6.0.10;
- Npgsql.EntityFrameworkCore.PostgreSQL 6.0.7;
To interact with Swagger:
- Swashbuckle.AspNetCore 6.2.3;
- Swashbuckle.AspNetCore.Swagger 6.2.3;
- Swashbuckle.AspNetCore.SwaggerGen 6.2.3;
- Swashbuckle.AspNetCore.SwaggerUI 6.2.3;
For unit testing and mocking purposes:
	- xUnit.Net 2.4.1
	- Moq 4.18.3

# To run application
- Configure Connection String in appsettings.json file 
- Dependencies indicated above (section "Technologies used") should be installed
- Restore migrations, if needed

# Migrations:
1. To add migration use command: 

```

dotnet ef migrations add [name]

```
2. Update DataBase: 

```

dotnet ef database update

```

Use the following command in terminal for working with migrations, if needed. For some reason terminal didn't recognise "dotnet ef" command even with MS EF Tools installed (observation is based on two different machines): 

```

dotnet tool install --global dotnet-ef --version 6.*

```

