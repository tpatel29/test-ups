# Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY project/*.csproj ./project/
RUN dotnet restore project/project.csproj

# copy everything else and build app
COPY project/. ./project/
WORKDIR /app/project
RUN dotnet publish -c Release -o out

# build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app/project/out ./
ENTRYPOINT ["dotnet", "project.dll"]
