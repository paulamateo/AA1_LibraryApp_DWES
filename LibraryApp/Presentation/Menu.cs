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
            Console.WriteLine("");
            _style.PrintMenu("1 - Buscar\n2 - Mostrar libros disponibles\n3 - Mostrar películas disponibles\n4 - Historial del usuario\n5 - Volver");
        }

        public (string? name, string? lastname, string? email, string? password, int phoneNumber) DisplayPanelforCreateAccount() {
            DisplayOptionTitle(":mobile_phone_with_arrow: CREAR CUENTA");
            _style.PrintBold("\nNombre:");
            string? name = Console.ReadLine();
            _style.PrintBold("Apellidos:");
            string? lastname = Console.ReadLine();
            _style.PrintBold("Correo electrónico:");
            string? email = Console.ReadLine();
            _style.PrintBold("Teléfono:");
            int phoneNumber = Convert.ToInt32(Console.ReadLine());
            _style.PrintBold("Contraseña:");
            string? password = Console.ReadLine();
            return (name, lastname, email, password, phoneNumber);
        }

        public (string? email, string? password) DisplayPanelforLogin() {
            DisplayOptionTitle(":mobile_phone: INICIAR SESIÓN");
            _style.PrintBold("\nCorreo electrónico:");
            string? email = Console.ReadLine();
            _style.PrintBold("Contraseña:");
            string? password = Console.ReadLine();
            return (email, password);
        }

        public void DisplayPanelforActions() {
            while (true) { 
                PrintOption();
                var optionAction = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");
                switch (optionAction) {
                    case 1:
                        DisplaySearch();
                        DisplaySecondMenu();
                        break;
                    case 2:
                        DisplayTableBooks();
                        DisplaySecondMenu();
                        break;
                    case 3:
                        DisplayTableFilms();
                        DisplaySecondMenu();
                        break;
                    case 4:
                        DisplayHistorialAccount();
                        DisplaySecondMenu();
                        break;
                    case 5:
                        break;
                    default:
                        _style.PrintError($"\nLa opción {optionAction} no está en el menú.\n");
                        break;
                }
                if (optionAction == 5) {
                    break;
                }
            }
        }
        
        public void DisplayTableBooks() {
            _style.PrintOptionTitle(":closed_book: LIBROS DISPONIBLES"); 
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
            _style.PrintOptionTitle(":film_projector: PELÍCULAS DISPONIBLES"); 
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
            _style.PrintWarning("\n:a_button_blood_type: ¡Recuerda! Debes escribirlo bien.\n");
            _style.PrintBold("Título del libro o película:");
            string? title = Console.ReadLine();
            bool titleSearch = _libraryService.SearchFunctionality(title);
            if (titleSearch) {
                _style.PrintBold($"\n¡Sí :beaming_face_with_smiling_eyes:, tenemos el título que buscas!\n¿Te gustaría ver o leer '{title}'? Escribe 1 (Sí) / 2 (No)");
                var answer = Convert.ToInt32(Console.ReadLine());
                switch(answer) {
                    case 1:
                        _libraryService.AddItemToHistory(title);
                        Console.WriteLine($"\n'{title}' ha sido añadido a tu historial. En breve recibirás un correo electrónico con el contenido solicitado.\n");
                        break;
                    case 2:
                        Console.WriteLine("");
                        break;
                    default:
                        _style.PrintError("¡Esa opción no existe!\n");
                        break;
                }
            }else {
                AnsiConsole.MarkupLine("\nLo sentimos :confounded_face:, no disponemos de ese título.\n");
            }
        }

        public void DisplayHistorialAccount() {
            _style.PrintOptionTitle(":spiral_calendar: HISTORIAL DE VISUALIZACIÓN Y LECTURA"); 
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
                Console.WriteLine("");
            }else {
                Console.WriteLine("\nNo has leído ni visto ningún título todavía.\n");
            }
        }

        public void DisplayOptionTitle(string optionName) {
            _style.PrintOptionTitle($"{optionName}\nIntroduce los datos que se piden a continuación");   
        }

         public void DisplayFarewell() { 
            _style.PrintInfo("\n¡Hasta pronto! :yellow_heart:");
        }

        public void AccountCreated() {
            _style.PrintSuccess("\n:check_mark_button: Cuenta creada exitosamente.\n");
        }

        public void PrintOption() {
            Console.WriteLine("");
            _style.PrintBold("ELIGE UNA OPCIÓN:");
        }

    }
}