#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ChronicFatigueUtils/ChronicFatigueUtils.csproj", "ChronicFatigueUtils/"]
RUN dotnet restore "ChronicFatigueUtils/ChronicFatigueUtils.csproj"
COPY . .
WORKDIR "/src/ChronicFatigueUtils"
RUN dotnet build "ChronicFatigueUtils.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChronicFatigueUtils.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0.0-preview.7-bullseye-slim-arm64v8
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChronicFatigueUtils.dll"]