@echo off
color 2
echo SharpCRUD - Create EntityFramework Migration
set /p migname= MigrationName:
dotnet ef migrations add %migname% --project .\SharpCRUD.Infrastructure\SharpCRUD.Infrastructure.csproj --startup-project .\SharpCRUD.RestAPI\SharpCRUD.RestAPI.csproj
pause