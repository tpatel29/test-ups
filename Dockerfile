FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy the project file and restore dependencies
COPY UPS_Project/*.csproj ./UPS_Project/
RUN dotnet restore UPS_Project/UPS_Project.csproj

# Copy the application files and build the application
COPY UPS_Project/. ./UPS_Project/
WORKDIR /app/UPS_Project
RUN dotnet build -c Release

# Install the required components for Microsoft Identity
RUN apt-get update && apt-get install -y libgdiplus && ln -s /usr/lib/libgdiplus.so/usr/lib/gdiplus.dll

# Publish the application
RUN dotnet publish -c Release -o out

# Set the base image to the official .NET 7.0 ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/UPS_Project/out ./
ENTRYPOINT ["dotnet", "UPS_Project.dll"]
