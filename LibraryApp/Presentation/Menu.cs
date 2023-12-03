using LibraryApp.Business;
using Spectre.Console;

namespace LibraryApp.Presentation {
    public class Menu {
        private readonly ILibraryService _libraryService;
        private readonly Style _style;

        public Menu(ILibraryService libraryService, Style style) {
            _libraryService = libraryService;
            _style = style;
        }

        public void DisplayWelcome() { 
            _style.PrintInfo("BIBLIOTECA MULTIMEDIA 'NEXVERSE'\n");
        }

        public void DisplayMainMenu() {
            _style.PrintMenu("1 - Crear cuenta\n2 - Iniciar sesión\n3 - Salir");
        }

        public void DisplaySecondMenu() {
            _style.PrintMenu("1 - Buscar\n2 - Mostrar libros disponibles\n3 - Mostrar películas disponibles\n4 - Historial del usuario\n5 - Volver");
        }

        public (string? name, string? lastname, string? email, string? password, int phoneNumber) DisplayPanelforCreateAccount() {
            DisplayOptionTitle("CREAR CUENTA");
            Console.WriteLine("\nNombre:");
            string? name = Console.ReadLine();
            Console.WriteLine("Apellidos:");
            string? lastname = Console.ReadLine();
            Console.WriteLine("Correo electrónico");
            string? email = Console.ReadLine();
            Console.WriteLine("Teléfono:");
            int phoneNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Contraseña:");
            string? password = Console.ReadLine();
            return (name, lastname, email, password, phoneNumber);
        }

        public (string? email, string? password) DisplayPanelforLogin() {
            DisplayOptionTitle("INICIAR SESIÓN");
            Console.WriteLine("\nCorreo electrónico:");
            string? email = Console.ReadLine();
            Console.WriteLine("Contraseña:");
            string? password = Console.ReadLine();
            return (email, password);
        }

        public void DisplayPanelforActions(int? optionAction) {
            switch(optionAction) {
                case 1:
                    _style.PrintOptionTitle("BÚSQUEDA DE LIBROS Y PELÍCULAS\nIntroduce el título del libro o película que deseas buscar\n"); 
                    Console.WriteLine("Título:");  
                    string? title = Console.ReadLine();
                    //mostrar pelicula/libro (si existe) y preguntar si se desea ver/ leer
                    break;
                case 2:
                    DisplayTableBooks();
                    break;
                case 3:
                    DisplayTableFilms(); 
                    break;
                case 4:
                    DisplayHistorialAccount();
                    break;
                case 5:
                    DisplayMainMenu();
                    break;
                default:
                    _style.PrintError($"\nLa opción {optionAction} no está en el menú.\n");
                    break;
                }
        }


        public void DisplayTableBooks() {
            _style.PrintOptionTitle("LIBROS DISPONIBLES"); 
            var tableBooks = new Table()    
                .AddColumn("Título")
                .AddColumn("Autor")
                .AddColumn("Publicación")
                .AddColumn("Páginas")
                .AddColumn("Editorial")
                .AddColumn("Género")
            ;
            var booksRows = _libraryService.GetBooksRows();
            foreach (var row in booksRows) {
                tableBooks.AddRow(row);
            }
            AnsiConsole.Write(tableBooks);
            Console.WriteLine("");
        }

        public void DisplayTableFilms() {
            _style.PrintOptionTitle("PELÍCULAS DISPONIBLES"); 
            var tableFilms = new Table()    
                .AddColumn("Título")
                .AddColumn("Director")
                .AddColumn("Publicación")
                .AddColumn("Duración")
                .AddColumn("Género")
                .AddColumn("Edad recomendada")
            ;
            var filmsRows = _libraryService.GetFilmsRows();
            foreach (var row in filmsRows) {
                tableFilms.AddRow(row);
            }
            AnsiConsole.Write(tableFilms);
            Console.WriteLine("");
        }

        public void DisplayHistorialAccount() {
            _style.PrintOptionTitle("HISTORIAL DE VISUALIZACIÓN Y LECTURA\n"); 
        }

        public void DisplayOptionTitle(string optionName) {
            _style.PrintOptionTitle($"{optionName}\nIntroduce los datos que se piden a continuación");   
        }

         public void DisplayFarewell() { 
            _style.PrintInfo("\n¡Hasta pronto!");
        }

    }
}