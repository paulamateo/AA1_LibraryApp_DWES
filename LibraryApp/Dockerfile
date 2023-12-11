# Establecer la imagen base con el SDK de .NET para construir la aplicación
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# --- Capa Data ---
COPY Data/LibraryApp.Data.csproj ./Data/
RUN dotnet restore ./Data/LibraryApp.Data.csproj

# --- Capa Models ---
COPY Models/LibraryApp.Models.csproj ./Models/
RUN dotnet restore ./Models/LibraryApp.Models.csproj

# --- Capa Business ---
COPY Business/LibraryApp.Business.csproj ./Business/
RUN dotnet restore ./Business/LibraryApp.Business.csproj

# --- Capa Presentation ---
COPY Presentation/LibraryApp.Presentation.csproj ./Presentation/

# Restaurar los proyectos de la capa Presentation
RUN dotnet restore ./Presentation/LibraryApp.Presentation.csproj

# Cambiar al directorio de trabajo de la capa Presentation
WORKDIR /app/Presentation

# Copiar todos los archivos y compilar la aplicación
COPY . ./

# Modificar la ruta del comando dotnet build
RUN dotnet build -c Release -o /app/out Presentation/LibraryApp.Presentation.csproj

# Crear un volumen en /app/Data para persistir datos de la capa Data
VOLUME /app/Data

# Establecer la imagen base final con ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app/Presentation
COPY --from=build /app/out .

# Exponer puertos y configurar el punto de entrada
EXPOSE 6619
EXPOSE 6611

ENTRYPOINT ["dotnet", "LibraryApp.Presentation.dll"]