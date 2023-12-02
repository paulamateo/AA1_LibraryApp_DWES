using LibraryApp.Presentation;
using LibraryApp.Data;
using LibraryApp.Business;

var _libraryRepository = new LibraryRepository();
var _libraryService = new LibraryService(_libraryRepository);

bool exit = false;
Menu.DisplayWelcome();
Menu.DisplayPrincipalMenu();

while (!exit) {
    Console.WriteLine("\nELIGE UNA OPCIÓN:");
    try {
        var option = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");
        switch(option) {
            case 1:
                //LOGIN
                // Menu.DisplayOptionTitle("INICIAR SESIÓN");
                // Console.WriteLine("Correo electrónico");
                // string? emailLogin = Console.ReadLine();
                // Console.WriteLine("Contraseña");
                // string? passwordLogin = Console.ReadLine();
                
                // bool isAuthenticated = _libraryService.AuthenticateUser(emailLogin, passwordLogin);
                // Menu.AccountExists(isAuthenticated);
                break;
            case 2:
                //CREAR CUENTA
                Menu.DisplayOptionTitle("CREAR CUENTA");
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
                Console.WriteLine("Confirmar contraseña:");
                string? secondPassword = Console.ReadLine();

                bool userCreated = _libraryService.CreateNewUser(name, lastname, email, password, phoneNumber);
                Menu.AccountIsCreated(userCreated);
                break;
            case 3:
                //SALIR
                exit = true;
                Menu.DisplayFarewell();
                break;
            case 4:
            //LISTAR CUENTAS QUE HAY EN EL DICCIONARIO
                _libraryService.DisplayUsers();
                break;
            default:
                Style.PrintError($"\nLa opción {option} no está en el menú.\n");
                break;
        }
    }catch (FormatException) {
        Style.PrintError($"\nError de formato. Debes introducir un carácter válido.\n");
    }
}