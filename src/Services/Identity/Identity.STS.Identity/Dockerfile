FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Identity.STS.Identity/Identity.STS.Identity.csproj", "src/Identity.STS.Identity/"]
COPY ["src/Identity.Shared.Configuration/Identity.Shared.Configuration.csproj", "src/Identity.Shared.Configuration/"]
COPY ["src/Identity.Admin.EntityFramework.Shared/Identity.Admin.EntityFramework.Shared.csproj", "src/Identity.Admin.EntityFramework.Shared/"]
COPY ["src/Identity.Admin.EntityFramework.Identity/Identity.Admin.EntityFramework.Identity.csproj", "src/Identity.Admin.EntityFramework.Identity/"]
COPY ["src/Identity.Admin.EntityFramework/Identity.Admin.EntityFramework.csproj", "src/Identity.Admin.EntityFramework/"]
COPY ["src/Identity.Admin.EntityFramework.Extensions/Identity.Admin.EntityFramework.Extensions.csproj", "src/Identity.Admin.EntityFramework.Extensions/"]
COPY ["src/Identity.Admin.EntityFramework.Configuration/Identity.Admin.EntityFramework.Configuration.csproj", "src/Identity.Admin.EntityFramework.Configuration/"]
COPY ["src/Identity.Shared/Identity.Shared.csproj", "src/Identity.Shared/"]
COPY ["src/Identity.Admin.BusinessLogic.Identity/Identity.Admin.BusinessLogic.Identity.csproj", "src/Identity.Admin.BusinessLogic.Identity/"]
COPY ["src/Identity.Admin.BusinessLogic.Shared/Identity.Admin.BusinessLogic.Shared.csproj", "src/Identity.Admin.BusinessLogic.Shared/"]
RUN dotnet restore "src/Identity.STS.Identity/Identity.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/Identity.STS.Identity"
RUN dotnet build "Identity.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Identity.STS.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "Identity.STS.Identity.dll"]