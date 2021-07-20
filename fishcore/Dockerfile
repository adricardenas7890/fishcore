#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base

# Need to include npm and nodejs

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["fishcore/fishcore.csproj", "fishcore/"]
RUN dotnet restore "fishcore/fishcore.csproj"
COPY . .
WORKDIR "/src/fishcore"
RUN dotnet build "fishcore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "fishcore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "fishcore.dll"]