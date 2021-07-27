FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Identity.Admin/Identity.csproj", "src/Identity.Admin/"]
COPY ["src/Identity.EntityFramework.MySql/Identity.EntityFramework.MySql.csproj", "src/Identity.EntityFramework.MySql/"]
COPY ["src/Identity.EntityFramework.Identity/Identity.EntityFramework.Identity.csproj", "src/Identity.EntityFramework.Identity/"]
COPY ["src/Identity.EntityFramework/Identity.EntityFramework.csproj", "src/Identity.EntityFramework/"]
COPY ["src/Identity.EntityFramework.Extensions/Identity.EntityFramework.Extensions.csproj", "src/Identity.EntityFramework.Extensions/"]
COPY ["src/Identity.EntityFramework.Shared/Identity.EntityFramework.Shared.csproj", "src/Identity.EntityFramework.Shared/"]
COPY ["src/Identity.BusinessLogic/Identity.BusinessLogic.csproj", "src/Identity.BusinessLogic/"]
COPY ["src/Identity.BusinessLogic.Shared/Identity.BusinessLogic.Shared.csproj", "src/Identity.BusinessLogic.Shared/"]
COPY ["src/Identity.EntityFramework.PostgreSQL/Identity.EntityFramework.PostgreSQL.csproj", "src/Identity.EntityFramework.PostgreSQL/"]
COPY ["src/Identity.BusinessLogic.Identity/Identity.BusinessLogic.Identity.csproj", "src/Identity.BusinessLogic.Identity/"]
COPY ["src/Identity.EntityFramework.SqlServer/Identity.EntityFramework.SqlServer.csproj", "src/Identity.EntityFramework.SqlServer/"]
COPY ["src/Identity.Shared/Identity.Shared.csproj", "src/Identity.Shared/"]
RUN dotnet restore "src/Identity.Admin/Identity.csproj"
COPY . .
WORKDIR "/src/src/Identity.Admin"
RUN dotnet build "Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "Identity.dll"]