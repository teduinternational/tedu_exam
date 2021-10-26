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

## Deploy system to IIS on Windows 10

### Setup environment:
- Windows 10 or Windows Server
- IIS
- URL Rewrite Module: https://www.iis.net/downloads/microsoft/url-rewrite
- .NET Hosting Bundle: https://dotnet.microsoft.com/download/dotnet/5.0
- MongoDB
- SQL Server

### Deploy
1. Upgrade MudBlazor
2. Setup self certificate in IIS
- Open file host assign new domain to 127.0.0.1: C:\windows\System32\drivers\etc
+ exam-api.local
+ identity-sts.local
+ identity-admin.local
+ admin.local
+ portal.local

- Create new website with port 80
- Create new SSL and Export to PFX file:

$domain= "portal.local"
$password= "@OurPassword1" | ConvertTo-SecureString -AsPlainText -Force
New-SelfSignedCertificate -NotBefore (Get-Date) -NotAfter (Get-Date).AddYears(1) -Subject $domain -KeyAlgorithm "RSA" -KeyLength 2048 -HashAlgorithm "SHA256" -CertStoreLocation "Cert:\CurrentUser\My" -KeyUsage KeyEncipherment -FriendlyName $domain -TextExtension @("2.5.29.19={critical}{text}","2.5.29.37={critical}{text}1.3.6.1.5.5.7.3.1","2.5.29.17={critical}{text}DNS=$domain")

3. Export certificate to PFX file

$domain= "portal.local"
$certificate = Get-ChildItem -Path Cert:\CurrentUser\My\ | Where-Object {$_.Subject -match $domain}
$password= "@OurPassword1" | ConvertTo-SecureString -AsPlainText -Force

Export-PfxCertificate -Cert $certificate -FilePath $env:USERPROFILE\Documents\$domain.pfx -Password $password

4. Trust  Open MMC run: certmgr.msc --> Personal Certificate --> Copy Admin.local cert --> Paste to Trusted Root Certificate --> Certificates

5. Import to IIS --> Server Certificate --> Import --> Choose PFX

6. Binding to website 443 and choose certificate

7. Click to website in IIS -> Choose SSL Setting --> Accept

--------------------------------------------------------------------------------
Fix error (if any):
- Check SQL and MongoDB Service in (services.msc)
- Enable SQL Authentication --> righ click to SQL Server --> Properties
- Change trusted connection in appsettings.json to user and password
- Create new user in SQL for each system
- Open connection MongoDB, create user in Mongodb: C:\Program Files\MongoDB\Server\5.0\bin\mongod.cfg
security:
  authorization: 'enabled'

- using UseIISIntegration() in Program.cs in ASP.NET Core

Reference: https://dev.to/iamthecarisma/managing-windows-pfx-certificates-through-powershell-3pj
Powershell: Goto Current User cert:  cd cert:\CurrentUser\My

