# Base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy project file and restore dependencies
COPY backend/Admin.Api/Admin.Api.csproj ./Admin.Api/
RUN dotnet restore "Admin.Api/Admin.Api.csproj"

# Copy the rest of the application code
COPY backend/Admin.Api/. ./Admin.Api/
WORKDIR "/src/Admin.Api"
RUN dotnet build "Admin.Api.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "Admin.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Admin.Api.dll"]
