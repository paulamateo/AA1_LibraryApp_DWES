# Aplicación "NexVerse Library"

<div align="center" >
  <img src="https://github.com/paulamateo/NexVerse_Library/assets/118843344/40f26bfe-bcfd-47fe-9a05-c1413f9362fa" alt="Logotipo" height="100px">
</div>

La aplicación "NexVerse Library" se erige como una biblioteca multimedia online que fusiona la literatura con la magia del cine. Su **propósito** fundamental es proporcionar a los usuarios un acceso fácil a la cultura, eliminando la necesidad de desplazarse físicamente a una biblioteca. La plataforma ofrece una experiencia única al permitir a los usuarios disfrutar de libros y películas para todos los públicos de manera legal y completamente gratuita, todo ello desde la comodidad de sus hogares.

La experiencia de ser un usuario de “NexVerse Library” implica disfrutar de las diversas **características** que ofrece este programa:
- Acceso a un amplio catálogo: Los usuarios tienen la posibilidad de explorar un extenso catálogo que abarca tanto libros como películas. Esta biblioteca en línea permite un acceso inmediato a los contenidos, brindando información detallada sobre cada obra, como título, autor/director, duración/páginas, año de publicación, género, entre otros.
- Motor de búsqueda eficiente: “NexVerse Library” cuenta con un motor de búsqueda que facilita a los usuarios encontrar rápidamente el libro o la película que desean introduciendo el título de la película o libro que quieren.
- Historial de visualización y lectura: Cada usuario dispone de una "cuartilla" personalizada que documenta las obras que ha consumido de la biblioteca. Este historial, además de los títulos, incluye la fecha en la que se solicitó el recurso. Esta función permite a los usuarios realizar un seguimiento detallado de lo que ya ha leído o visualizado de la biblioteca.

## Arquitectura por capas: Comandos
Creación de una capa de tipo librería:

        dotnet new classlib -n LibraryApp.CAPA -o CAPA

Creación de una capa de tipo consola:

        dotnet new console -n LibraryApp.CAPA -o CAPA

Creación de la API:

        dotnet new webapi -n LibraryApp.API -o API
        
Referencias de las capas en la solución `LibraryApp.sln`:

      dotnet sln add CAPA/LibraryApp.CAPA.csproj

Referencias entre unas capas y otras:

        dotnet add Data/LibraryApp.Data.csproj reference Models/LibraryApp.Models.csproj 
        dotnet add Business/LibraryApp.Business.csproj reference Data/LibraryApp.Data.csproj 
        dotnet add Presentation/LibraryApp.Presentation.csproj reference Business/LibraryApp.Business.csproj 
        


