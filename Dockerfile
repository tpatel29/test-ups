# Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY UPS_Project/*.csproj ./UPS_Project/
RUN dotnet restore UPS_Project/UPS_Project.csproj

# copy everything else and build app
COPY UPS_Project/. ./UPS_Project/
WORKDIR /app/UPS_Project
RUN dotnet publish -c Release -o out

# build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app/UPS_Project/out ./
ENTRYPOINT ["dotnet", "UPS_Project.dll"]

