using LibraryApp.Presentation;
using LibraryApp.Data;
using LibraryApp.Business;

var _libraryRepository = new LibraryRepository();
var _libraryService = new LibraryService(_libraryRepository);

Menu _menu = new Menu();
Style _style = new Style();

bool exit = false;
_menu.DisplayWelcome();
_menu.DisplayPrincipalMenu();

while (!exit) {
    Console.WriteLine("\nELIGE UNA OPCIÓN:");
    try {
        var option = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");
        switch(option) {
            case 1:
                //CREAR CUENTA
                var (name, lastname, email, password, phoneNumber) = _menu.DisplayPaneltoCreateAccount();
                bool userCreated = _libraryService.CreateNewUser(name, lastname, email, password, phoneNumber);
                _menu.AccountIsCreated(userCreated);
                break;
            case 2:
                //INICIAR SESIÓN


                // _libraryService.DisplayBooks();
                //LOGIN
                // Menu.DisplayOptionTitle("INICIAR SESIÓN");
                // Console.WriteLine("Correo electrónico");
                // string? emailLogin = Console.ReadLine();
                // Console.WriteLine("Contraseña");
                // string? passwordLogin = Console.ReadLine();
                
                // bool isAuthenticated = _libraryService.AuthenticateUser(emailLogin, passwordLogin);
                // Menu.AccountExists(isAuthenticated);


                break;
            case 3:
                //SALIR
                exit = true;
                _menu.DisplayFarewell();
                break;
            case 4:
            //LISTAR CUENTAS QUE HAY EN EL DICCIONARIO
                _libraryService.DisplayUsers();
                break;
            default:
                _style.PrintError($"\nLa opción {option} no está en el menú.\n");
                break;
        }
    }catch (FormatException) {
        _style.PrintError($"\nError de formato. Debes introducir un carácter válido.\n");
    }
}