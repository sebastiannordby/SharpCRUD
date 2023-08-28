#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SharpCRUD.RestAPI/SharpCRUD.RestAPI.csproj", "SharpCRUD.RestAPI/"]
COPY ["SharpCRUD.Domain.UseCases/SharpCRUD.Domain.UseCases.csproj", "SharpCRUD.Domain.UseCases/"]
COPY ["SharpCRUD.Domain/SharpCRUD.Domain.csproj", "SharpCRUD.Domain/"]
COPY ["SharpCRUD.DataAccess/SharpCRUD.DataAccess.csproj", "SharpCRUD.DataAccess/"]
COPY ["SharpCRUD.Infrastructure/SharpCRUD.Infrastructure.csproj", "SharpCRUD.Infrastructure/"]
COPY ["SharpCRUD.Library/SharpCRUD.Library.csproj", "SharpCRUD.Library/"]
RUN dotnet restore "SharpCRUD.RestAPI/SharpCRUD.RestAPI.csproj"
COPY . .
WORKDIR "/src/SharpCRUD.RestAPI"
RUN dotnet build "SharpCRUD.RestAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SharpCRUD.RestAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SharpCRUD.RestAPI.dll"]

