# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar solo el archivo de proyecto y restaurar dependencias
COPY APIObesidad.csproj .
RUN dotnet restore

# Copiar todo el código fuente y compilar la aplicación
COPY . .
RUN dotnet publish -c Release -o /app

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar los archivos publicados desde la etapa de compilación
COPY --from=build /app .

# Exponer el puerto que la aplicación escucha
EXPOSE 8080
EXPOSE 8081

# Punto de entrada para la aplicación
ENTRYPOINT ["dotnet", "APIObesidad.dll"]
