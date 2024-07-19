# Utiliza la imagen de base oficial de Microsoft para .NET 6.0 SDK para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copia csproj y restaura las dependencias
COPY *.csproj ./
RUN dotnet restore

# Copia los archivos del proyecto y construye la aplicación
COPY . ./
RUN dotnet publish -c Release -o out

# Genera la imagen final
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "mapeosAPI.dll"]
