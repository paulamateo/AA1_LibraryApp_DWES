FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /LibraryApp
COPY . .
EXPOSE 6619
RUN dotnet publish "/LibraryApp.Presentation/LibraryApp.Presentation.csproj" -c Release -o /LibraryApp
ENTRYPOINT [ "dotnet", "LibraryApp.Presentation.dll" ]