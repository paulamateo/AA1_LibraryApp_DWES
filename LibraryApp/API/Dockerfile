FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
COPY API/*.csproj ./
RUN dotnet restore
COPY API/. ./
RUN dotnet build -c Release -o /out

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS runtime
WORKDIR /app
COPY --from=build /out ./
