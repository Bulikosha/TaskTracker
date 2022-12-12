# TaskTracker

Technologies used:
- Microsoft.EntityFrameworkCore 6.0.10;
- Microsoft.EntityFrameworkCore.Tools 6.0.10;
- Npgsql.EntityFrameworkCore.PostgreSQL 6.0.7;
- Microsoft.EntityFrameworkCore.Tools.DotNet 2.0.3;

Use the following command in terminal: dotnet tool install --global dotnet-ef --version 6.*. For some reason terminal didn't recognise "dotnet ef" command even with MS EF Tools installed.

Migrations:
1. To add migration use command: dotnet ef migrations add [name]
2. Update DataBase: dotnet ef database update