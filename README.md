# TEDU Exam Project

## Application URLs:
- Identity STS: https://localhost:5001
- Exam API: https://localhost:5002
- Identity API: https://localhost:5003
- Exam Admin: https://localhost:6001
- Exam Portal: https://localhost:6002
- Identity Admin: https://localhost:6003

## Docker Command Examples
- docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Admin@123$' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest
- docker ps or docker container ls
- docker run -d --name mongodb -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=Admin@123$ -p 127.0.0.1:27017:27017 mongo
- Clone Quick Start UI: 
curl -L https://raw.githubusercontent.com/IdentityServer/IdentityServer4.Quickstart.UI/main/getmain.sh | bash

iex ((New-Object System.Net.WebClient).DownloadString('https://raw.githubusercontent.com/IdentityServer/IdentityServer4.Quickstart.UI/main/getmain.ps1'))


## Drop database 
USE master;
GO

ALTER DATABASE [Identity] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO
DROP DATABASE [Identity];
GO

## Packages References
- https://github.com/serilog/serilog/wiki/Getting-Started
- https://github.com/IdentityServer/IdentityServer4.Quickstart.UI
- https://mudblazor.com/
- https://github.com/Garderoben/MudBlazor.Templates

## Install Environment
- https://dotnet.microsoft.com/download/dotnet/3.1
- https://dotnet.microsoft.com/download/dotnet/5.0
- https://visualstudio.microsoft.com/
- https://www.youtube.com/watch?v=fjadnDlo0RA
- https://www.microsoft.com/en-us/sql-server/sql-server-downloads
- https://docs.mongodb.com/manual/tutorial/install-mongodb-on-windows/
- https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15
- https://robomongo.org/

# Local secret

## Exam API

{
  "DatabaseSettings": {
    "Server": "localhost:27017",
    "DatabaseName": "ExamDb",
    "User": "admin",
    "Password": "Admin%40123%24"
  },
  "IdentityUrl": "https://localhost:5001"
}

## Identity.Admin
{
  "ConnectionStrings": {
    "ConfigurationDbConnection": "Server=.;Database=IdentityDb;Trusted_Connection=True;MultipleActiveResultSets=true",
    "PersistedGrantDbConnection": "Server=.;Database=IdentityDb;Trusted_Connection=True;MultipleActiveResultSets=true",
    "IdentityDbConnection": "Server=.;Database=IdentityDb;Trusted_Connection=True;MultipleActiveResultSets=true",
    "AdminLogDbConnection": "Server=.;Database=IdentityDb;Trusted_Connection=True;MultipleActiveResultSets=true",
    "AdminAuditLogDbConnection": "Server=.;Database=IdentityDb;Trusted_Connection=True;MultipleActiveResultSets=true",
    "DataProtectionDbConnection": "Server=.;Database=IdentityDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "AdminConfiguration": {
    "IdentityAdminRedirectUri": "https://localhost:6003/signin-oidc",
    "IdentityServerBaseUrl": "https://localhost:5001",
  }
}

## Identity.STS
{
  "ConnectionStrings": {
    "ConfigurationDbConnection": "Server=.;Database=IdentityDb;Trusted_Connection=True;MultipleActiveResultSets=true",
    "PersistedGrantDbConnection": "Server=.;Database=IdentityDb;Trusted_Connection=True;MultipleActiveResultSets=true",
    "IdentityDbConnection": "Server=.;Database=IdentityDb;Trusted_Connection=True;MultipleActiveResultSets=true",
    "DataProtectionDbConnection": "Server=.;Database=IdentityDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "AdminConfiguration": {
    "IdentityAdminBaseUrl": "https://localhost:6003",
  }
}

# Admin API
{
  "ConnectionStrings": {
    "ConfigurationDbConnection": "Server=.;Database=IdentityDb;Trusted_Connection=True;MultipleActiveResultSets=true",
    "PersistedGrantDbConnection": "Server=.;Database=IdentityDb;Trusted_Connection=True;MultipleActiveResultSets=true",
    "IdentityDbConnection": "Server=.;Database=IdentityDb;Trusted_Connection=True;MultipleActiveResultSets=true",
    "AdminLogDbConnection": "Server=.;Database=IdentityDb;Trusted_Connection=True;MultipleActiveResultSets=true",
    "AdminAuditLogDbConnection": "Server=.;Database=IdentityDb;Trusted_Connection=True;MultipleActiveResultSets=true",
    "DataProtectionDbConnection": "Server=.;Database=IdentityDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "AdminApiConfiguration": {
    "ApiBaseUrl": "https://localhost:5003",
    "IdentityServerBaseUrl": "https://localhost:5001",
  }
}

## References URLS
- https://samwalpole.com/using-scoped-services-inside-singletons
- https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-5.0
- 