using LibraryApp.Presentation;
using LibraryApp.Data;
using LibraryApp.Business;


var _libraryRepository = new LibraryRepository();
var _libraryService = new LibraryService(_libraryRepository);
var _logService = new LogService();
Menu _menu = new Menu(_libraryService, _logService);


bool exit = false;
_menu.DisplayWelcome();

while (!exit) {
    try {
        _menu.DisplayMainMenu();
        _menu.PrintOption();
        var option = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");
        switch(option) {
            case 1:
                var (name, lastname, email, password, phoneNumber) = _menu.DisplayPanelforCreateAccount();
                bool userCreated = _libraryService.CreateUser(name, lastname, email, password, phoneNumber);
                
                if (userCreated) {
                    _menu.AccountCreated();
                    _libraryService.SetCurrentUser(email);
                    _menu.DisplaySecondMenu();
                    _menu.DisplayPanelforActions();
                }else {
                    _menu.DisplayError("El correo electrónico ya está asociado a una cuenta existente.\n");
                }
                break;
            case 2:
                var (emailLogin, passwordLogin) = _menu.DisplayPanelforLogin();
                bool isAuthenticated = _libraryService.AuthenticateUser(emailLogin, passwordLogin);

                if (isAuthenticated) {
                    _libraryService.SetCurrentUser(emailLogin);
                    _menu.DisplaySecondMenu();
                    _menu.DisplayPanelforActions();
                }else {
                    _menu.DisplayError("Inicio de sesión fallido. Comprueba que la contraseña o el correo sean correctos.\n");
                }
                break;
            case 3:
                exit = true;
                _menu.DisplayFarewell();
                break;
            default:
                _menu.DisplayError("Esa opción no está en el menú.\n");
                break;
        }
    }catch (FormatException) {
        _menu.DisplayError("Error de formato. Debes introducir un carácter válido.\n");
    }
}