FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Identity.Admin/Identity.Admin.csproj", "src/Identity.Admin/"]
COPY ["src/Identity.Admin.EntityFramework.MySql/Identity.Admin.EntityFramework.MySql.csproj", "src/Identity.Admin.EntityFramework.MySql/"]
COPY ["src/Identity.Admin.EntityFramework.Identity/Identity.Admin.EntityFramework.Identity.csproj", "src/Identity.Admin.EntityFramework.Identity/"]
COPY ["src/Identity.Admin.EntityFramework/Identity.Admin.EntityFramework.csproj", "src/Identity.Admin.EntityFramework/"]
COPY ["src/Identity.Admin.EntityFramework.Extensions/Identity.Admin.EntityFramework.Extensions.csproj", "src/Identity.Admin.EntityFramework.Extensions/"]
COPY ["src/Identity.Admin.EntityFramework.Shared/Identity.Admin.EntityFramework.Shared.csproj", "src/Identity.Admin.EntityFramework.Shared/"]
COPY ["src/Identity.Admin.EntityFramework.Configuration/Identity.Admin.EntityFramework.Configuration.csproj", "src/Identity.Admin.EntityFramework.Configuration/"]
COPY ["src/Identity.Admin.BusinessLogic/Identity.Admin.BusinessLogic.csproj", "src/Identity.Admin.BusinessLogic/"]
COPY ["src/Identity.Admin.BusinessLogic.Shared/Identity.Admin.BusinessLogic.Shared.csproj", "src/Identity.Admin.BusinessLogic.Shared/"]
COPY ["src/Identity.Admin.EntityFramework.PostgreSQL/Identity.Admin.EntityFramework.PostgreSQL.csproj", "src/Identity.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/Identity.Admin.BusinessLogic.Identity/Identity.Admin.BusinessLogic.Identity.csproj", "src/Identity.Admin.BusinessLogic.Identity/"]
COPY ["src/Identity.Admin.UI/Identity.Admin.UI.csproj", "src/Identity.Admin.UI/"]
COPY ["src/Identity.Shared.Configuration/Identity.Shared.Configuration.csproj", "src/Identity.Shared.Configuration/"]
COPY ["src/Identity.Shared/Identity.Shared.csproj", "src/Identity.Shared/"]
COPY ["src/Identity.Admin.EntityFramework.SqlServer/Identity.Admin.EntityFramework.SqlServer.csproj", "src/Identity.Admin.EntityFramework.SqlServer/"]
RUN dotnet restore "src/Identity.Admin/Identity.Admin.csproj"
COPY . .
WORKDIR "/src/src/Identity.Admin"
RUN dotnet build "Identity.Admin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Identity.Admin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "Identity.Admin.dll"]