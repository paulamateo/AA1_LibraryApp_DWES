using LibraryApp.Business;
using Spectre.Console;
using System;

namespace LibraryApp.Presentation
{
    public class Menu
    {
        private readonly ILibraryService _libraryService;
        private readonly LogService _logService;
        private readonly Style _style;

        public Menu(ILibraryService libraryService, LogService logService)
        {
            _libraryService = libraryService;
            _logService = logService;
            _style = new Style();
        }

        public void DisplayError(string errorMessage)
        {
            _style.PrintError(errorMessage);
            _logService.LogError(errorMessage);
        }

        public void DisplayWelcome()
        {
            _style.PrintInfo("\n:books::house:  BIBLIOTECA MULTIMEDIA 'NEXVERSE'\n");
        }

        public void DisplayMainMenu()
        {
            _style.PrintMenu("1 - Crear cuenta\n2 - Iniciar sesión\n3 - Salir");
        }

        public void DisplaySecondMenu()
        {
            Console.WriteLine("");
            _style.PrintMenu("1 - Buscar\n2 - Mostrar libros disponibles\n3 - Mostrar películas disponibles\n4 - Historial del usuario\n5 - Volver\n6 - Ver datos usuario");
        }

        public (string? name, string? lastname, string? email, string? password, int phoneNumber) DisplayPanelforCreateAccount()
        {
            DisplayOptionTitle(":ghost:  CREAR CUENTA");
            _style.PrintBold("\nNombre:");
            string? name = Console.ReadLine();
            _style.PrintBold("Apellidos:");
            string? lastname = Console.ReadLine();
            _style.PrintBold("Correo electrónico:");
            string? email = Console.ReadLine();
            int phoneNumber;
            while (true)
            {
                _style.PrintBold("Teléfono:");
                string? phoneNumberInput = Console.ReadLine();
                if (ValidatePhoneNumberLength(phoneNumberInput))
                {
                    phoneNumber = Convert.ToInt32(phoneNumberInput);
                    break;
                }
            }
            string? password = ReadPasswordFromConsole();
            return (name, lastname, email, password, phoneNumber);
        }

        public bool ValidatePhoneNumberLength(string phoneNumber)
        {
            if (phoneNumber.Length != 9)
            {
                DisplayError("El número de teléfono debe tener nueve caracteres.");
                return false;
            }
            return true;
        }

        public (string? email, string? password) DisplayPanelforLogin()
        {
            DisplayOptionTitle(":desktop_computer:  INICIAR SESIÓN");
            _style.PrintBold("\nCorreo electrónico:");
            string? email = Console.ReadLine();
            string? password = ReadPasswordFromConsole();
            return (email, password);
        }

        private string ReadPasswordFromConsole()
        {
            _style.PrintBold("Contraseña:");
            string password = "";

            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Backspace)
                {
                    if (password.Length > 0)
                    {
                        password = password.Substring(0, password.Length - 1);
                        Console.Write("\b \b"); 
                    }
                }
                else if (char.IsLetterOrDigit(key.KeyChar))
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }

            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine(); 
            return password;
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
            _style.PrintOptionTitle("BÚSQUEDA DE LIBROS Y PELÍCULAS\nIntroduce el título del libro o película que deseas buscar"); 
            _style.PrintWarning("\n¡Recuerda! Debes escribirlo bien.\n");
            _style.PrintBold("Título del libro o película:");
            string? title = Console.ReadLine();
            bool titleSearch = _libraryService.SearchFunctionality(title);
            if (titleSearch) {
                _style.PrintBold($"\n¡Sí, tenemos el título que buscas!\n¿Te gustaría ver o leer '{title}'? Escribe 1 (Sí) / 2 (No)");
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
            }else {
                AnsiConsole.MarkupLine("Lo sentimos, no disponemos de ese título.\n");
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
                Console.WriteLine("");
            }else {
                Console.WriteLine("\nNo has leído ni visto ningún título todavía.\n");
            }
        }

        public void DisplayOptionTitle(string optionName) {
            _style.PrintOptionTitle($"{optionName}\nIntroduce los datos que se piden a continuación");   
        }

         public void DisplayFarewell() { 
            _style.PrintInfo("¡Hasta pronto!");
        }

        public void AccountCreated() {
            _style.PrintSuccess("Cuenta creada exitosamente.\n");
        }

        public void PrintOption() {
            Console.WriteLine("");
            _style.PrintBold("ELIGE UNA OPCIÓN:");
        }

    }
}