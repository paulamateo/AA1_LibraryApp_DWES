using LibraryApp.Business;
using Spectre.Console;

namespace LibraryApp.Presentation {
    public class Menu {
        private readonly ILibraryService _libraryService;
        private readonly LogService _logService;
        private readonly Style _style;

        public Menu(ILibraryService libraryService, LogService logService) {
            _libraryService = libraryService;
            _logService = logService;
            _style = new Style();
        }

        public void DisplayError(string errorMessage) {
            _style.PrintError(errorMessage);
            _logService.LogError(errorMessage);
        }

        public void DisplayWelcome() { 
            _style.PrintInfo("\n:books::house:  BIBLIOTECA MULTIMEDIA 'NEXVERSE'\n");
        }

        public void DisplayMainMenu() {
            _style.PrintMenu("1 - Crear cuenta\n2 - Iniciar sesión\n3 - Salir");
        }

        public void DisplaySecondMenu() {
            Console.WriteLine("");
            _style.PrintMenu("1 - Buscar\n2 - Mostrar libros disponibles\n3 - Mostrar películas disponibles\n4 - Historial del usuario\n5 - Volver\n6 - Ver datos usuario");
        }

        public (string? name, string? lastname, string? email, string? password, int phoneNumber) DisplayPanelforCreateAccount() {
            DisplayOptionTitle(":ghost:  CREAR CUENTA");
            _style.PrintBold("\nNombre:");
            string? name = Console.ReadLine();
            _style.PrintBold("Apellidos:");
            string? lastname = Console.ReadLine();
            _style.PrintBold("Correo electrónico:");
            string? email = Console.ReadLine();
            int phoneNumber;
            while (true) {
                _style.PrintBold("Teléfono:");
                string? phoneNumberInput = Console.ReadLine();
                if (ValidatePhoneNumberLength(phoneNumberInput)) {
                    phoneNumber = Convert.ToInt32(phoneNumberInput);
                    break;
                }
            }
            _style.PrintBold("Contraseña:");
            string? password = Console.ReadLine();
            return (name, lastname, email, password, phoneNumber);
        }

        public bool ValidatePhoneNumberLength(string phoneNumber) {
            if (phoneNumber.Length != 9) {
                DisplayError("El número de teléfono debe tener nueve caracteres.");
                return false;
            }
            return true;
        }

        public (string? email, string? password) DisplayPanelforLogin() {
            DisplayOptionTitle(":desktop_computer:  INICIAR SESIÓN");
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
                        DisplayError($"La opción {optionAction} no está en el menú.\n");
                        break;
                }
                if (optionAction == 5) {
                    break;
                }
            }
        }
        
        public void DisplayTableBooks() {
            _style.PrintOptionTitle(":information:  LIBROS DISPONIBLES"); 
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
            _style.PrintOptionTitle(":information:  PELÍCULAS DISPONIBLES"); 
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
            _style.PrintOptionTitle("BÚSQUEDA DE LIBROS Y PELÍCULAS"); 
            Console.WriteLine("1 - Buscar por título (libro o película)");
            Console.WriteLine("2 - Buscar por autor (libro)");
            _style.PrintWarning("¡Recuerda! Debes escribirlo bien.\n");
            Console.WriteLine("\nElige una opción:");
            var option = Convert.ToInt32(Console.ReadLine());
            switch (option) {
                case 1:
                    SearchByTitle();
                    break;
                case 2:
                    SearchByAuthor();
                    break;
                default:
                    DisplayError("¡Esa opción no existe!\n");
                    break;
            }
        }

        private void SearchByTitle() {
            _style.PrintBold("\nTítulo del libro o película:");
            string? title = Console.ReadLine();

            if (_libraryService.SearchFunctionality(title)) {
                ProcessSearchResult(title);
            } else {
                AnsiConsole.MarkupLine("Lo sentimos, no tenemos ese título.  :broken_heart:\n");
            }
        }

        private void SearchByAuthor() {
            _style.PrintBold("Autor:");
            string author = Console.ReadLine();

            if (_libraryService.SearchAuthor(author)) {
                _style.PrintBold($"\n¡Sí, tenemos a '{author}' en nuestras estanterías! :grinning_face:\n¿Te gustaría leer alguna obra suya? Escribe 1 (SÍ) / 2 (NO)");
                var answerAuthor = Convert.ToInt32(Console.ReadLine());

                if (answerAuthor == 1) {
                    List<string> booksByAuthor = _libraryService.GetBooksByAuthor(author);

                    if (booksByAuthor.Count > 0) {
                        Console.WriteLine($"\nLibros de '{author}':");
                        foreach (var bookTitle in booksByAuthor) {
                            Console.WriteLine(bookTitle);
                        }

                        Console.WriteLine("\nLibro escogido:");
                        string selectedTitle = Console.ReadLine();

                        if (booksByAuthor.Contains(selectedTitle, StringComparer.OrdinalIgnoreCase)) {
                            ProcessSearchResult(selectedTitle);
                        } else {
                            Console.WriteLine($"No tenemos ese libro asociado con {author}.");
                        }
                    } else {
                        Console.WriteLine($"No se encontraron libros del autor {author}.");
                    }
                } else if (answerAuthor != 2) {
                    DisplayError("¡Esa opción no existe!\n");
                }
            }else {
                AnsiConsole.MarkupLine("Lo sentimos, no tenemos a ese autor en nuestras estanterías.  :broken_heart:\n");
            }
        }

        private void ProcessSearchResult(string title) {
            _style.PrintBold($"\n¡Sí, tenemos el título que buscas!  :grinning_face:\n¿Te gustaría ver o leer '{title}'? Escribe 1 (SÍ) / 2 (NO)");
            var answer = Convert.ToInt32(Console.ReadLine());

            switch(answer) {
                case 1:
                    _libraryService.AddItemToHistory(title);
                    _style.PrintItem($"\nDisfruta de {title} abriendo el siguiente enlace en tu navegador:");
                    string? link = _libraryService.GetLinkByTitle(title);
                    Console.WriteLine($"{link}");
                    break;
                case 2:
                    Console.WriteLine("");
                    break;
                default:
                    DisplayError("¡Esa opción no existe!\n");
                    break;
            }
        }


        public void DisplayHistorialAccount() {
            _style.PrintOptionTitle(":clipboard:  HISTORIAL DE VISUALIZACIÓN Y LECTURA"); 
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
            _style.PrintInfo("¡Hasta pronto!  :yellow_heart:");
        }

        public void AccountCreated() {
            _style.PrintSuccess(":check_mark_button:  Cuenta creada exitosamente.\n");
        }

        public void PrintOption() {
            Console.WriteLine("");
            _style.PrintBold(":eight_pointed_star:  ELIGE UNA OPCIÓN:");
        }

    }
}