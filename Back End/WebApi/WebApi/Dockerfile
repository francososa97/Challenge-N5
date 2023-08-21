#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebApi/WebApi.Aplication.csproj", "WebApi/"]
COPY ["WebApi.Models/WebApi.Models.csproj", "WebApi.Models/"]
COPY ["WebApi.Infraestructure/WebApi.Infraestructure.csproj", "WebApi.Infraestructure/"]
COPY ["WebApi.Repository/WebApi.Repository.csproj", "WebApi.Repository/"]
COPY ["WebApi.Services/WebApi.Services.csproj", "WebApi.Services/"]
RUN dotnet restore "WebApi/WebApi.Aplication.csproj"
COPY . .
WORKDIR "/src/WebApi"
RUN dotnet build "WebApi.Aplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApi.Aplication.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.Aplication.dll"]