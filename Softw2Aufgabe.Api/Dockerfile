#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Softw2Aufgabe.Api/Softw2Aufgabe.Api.csproj", "Softw2Aufgabe.Api/"]
RUN dotnet restore "Softw2Aufgabe.Api/Softw2Aufgabe.Api.csproj"
COPY . .
WORKDIR "/src/Softw2Aufgabe.Api"
RUN dotnet build "Softw2Aufgabe.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Softw2Aufgabe.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Softw2Aufgabe.Api.dll"]