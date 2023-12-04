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
            _style.PrintInfo(":books: BIBLIOTECA MULTIMEDIA 'NEXVERSE'\n");
        }

        public void DisplayMainMenu() {
            _style.PrintMenu("1 - Crear cuenta\n2 - Iniciar sesión\n3 - Salir");
        }

        public void DisplaySecondMenu() {
            _style.PrintMenu("1 - Buscar\n2 - Mostrar libros disponibles\n3 - Mostrar películas disponibles\n4 - Historial del usuario\n5 - Volver");
            DisplayPanelforActions();
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

        public void DisplayPanelforActions() {
            var optionAction = Convert.ToInt32(Console.ReadLine());
            switch(optionAction) {
                case 1:
                    DisplaySearch();
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

        public void DisplaySearch() {
            _style.PrintOptionTitle(":detective: BÚSQUEDA DE LIBROS Y PELÍCULAS\nIntroduce el título del libro o película que deseas buscar"); 
            _style.PrintWarning("\n:a_button_blood_type: ¡Recuerda! Debes respetar tanto los espacios como las mayúsculas y tildes de los títulos.\n");
            Console.WriteLine("Título del libro o película:");  
            string? title = Console.ReadLine();

            bool titleSearch = _libraryService.SearchFunctionality(title);
            if (titleSearch) {
                AnsiConsole.MarkupLine($"\n¡Sí :beaming_face_with_smiling_eyes:, tenemos el título que buscas!\n¿Te gustaría ver o leer '{title}'? Escribe 1 (Sí) / 2 (No)");
                var answer = Convert.ToInt32(Console.ReadLine());
                switch(answer) {
                    case 1:
                        _libraryService.AddItemToHistory(title);
                        Console.WriteLine($"\n{title} añadido a tu historial. En breve recibirás un correo electrónico con el contenido solicitado.\n");
                        DisplaySecondMenu();
                        break;
                    case 2:
                        DisplaySecondMenu();
                        break;
                    default:
                        _style.PrintError("¡Esa opción no existe!");
                        break;
                }
            }else {
                AnsiConsole.MarkupLine("\nLo sentimos :confounded_face:, no disponemos de ese título.\n");
            }
        }

        public void DisplayHistorialAccount() {
            _style.PrintOptionTitle("HISTORIAL DE VISUALIZACIÓN Y LECTURA"); 
            var history = _libraryService.GetHistoryRows();

            var tableHistory = new Table()
                .AddColumn("Fecha de escogida")    
                .AddColumn("Título")
            ;
            foreach (var row in history) {
                tableHistory.AddRow(row);
            }

            if (history.Count > 0) {
                Console.WriteLine("");
                AnsiConsole.Write(tableHistory);
            }else {
                Console.WriteLine("\nNo has leído ni visto ningún título todavía.");
            }
        }

        public void DisplayOptionTitle(string optionName) {
            _style.PrintOptionTitle($"{optionName}\nIntroduce los datos que se piden a continuación");   
        }

         public void DisplayFarewell() { 
            _style.PrintInfo("\n¡Hasta pronto!");
        }

    }
}