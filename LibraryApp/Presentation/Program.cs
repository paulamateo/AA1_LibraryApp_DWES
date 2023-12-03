using LibraryApp.Presentation;
using LibraryApp.Data;
using LibraryApp.Business;

var _libraryRepository = new LibraryRepository();
var _libraryService = new LibraryService(_libraryRepository);

Menu _menu = new Menu();
Style _style = new Style();

bool exit = false;
_menu.DisplayWelcome();
_menu.DisplayMainMenu();

while (!exit) {
    Console.WriteLine("\nELIGE UNA OPCIÓN:");
    try {
        var option = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");
        switch(option) {
            case 1:
                //CREAR CUENTA
                var (name, lastname, email, password, phoneNumber) = _menu.DisplayPanelforCreateAccount();
                bool userCreated = _libraryService.CreateNewUser(name, lastname, email, password, phoneNumber);

                if (userCreated) {
                    _style.PrintSuccess("\nCuenta creada exitosamente.\n");
                    _menu.DisplaySecondMenu();
                    var option_secMenu = Convert.ToInt32(Console.ReadLine());
                    switch(option_secMenu) {
                        case 1:
                            //BUSCAR
                            _style.PrintOptionTitle("BÚSQUEDA DE LIBROS Y PELÍCULAS\nIntroduce el título del libro o película que deseas buscar\n"); 
                            Console.WriteLine("Título:");  
                            //mostrar pelicula/libro (si existe) y preguntar si se desea ver/ leer
                            break;
                        case 2:
                            //MOSTRAR LIBROS
                            _style.PrintOptionTitle("LIBROS DISPONIBLES\n"); 

                            break;
                        case 3:
                            //MOSTRAR PELÍCULAS
                            _style.PrintOptionTitle("PELÍCULAS DISPONIBLES\n"); 
                            //mostrar peliculas, y preguntar si se decide 
                            break;
                        case 4:
                            //HISTORIAL DEL USUARIO
                            _style.PrintOptionTitle("HISTORIAL DE VISUALIZACIÓN Y LECTURA\n"); 
                            //muestra el historial de todo lo que ha visto y leído (si hay, claro)
                            break;
                        case 5:
                            //VOLVER
                            _menu.DisplayMainMenu();
                            break;
                        default:
                            _style.PrintError($"\nLa opción {option} no está en el menú.\n");
                            break;
                    }
                }else {
                    _style.PrintError("\nEl correo electrónico ya está asociado a una cuenta existente.\n");
                    _menu.DisplayMainMenu();
                }
                break;
            case 2:
                //INICIAR SESIÓN
                var (emailLogin, passwordLogin) = _menu.DisplayPanelforLogin();
                bool isAuthenticated = _libraryService.AuthenticateUser(emailLogin, passwordLogin);

                if (isAuthenticated) {
                    _menu.DisplaySecondMenu();
                    var option_secMenu = Convert.ToInt32(Console.ReadLine());
                    switch(option_secMenu) {
                        case 1:
                            //BUSCAR
                            _style.PrintOptionTitle("BÚSQUEDA DE LIBROS Y PELÍCULAS\nIntroduce el título del libro o película que deseas buscar\n"); 
                            Console.WriteLine("Título:");  
                            //mostrar pelicula/libro (si existe) y preguntar si se desea ver/ leer
                            break;
                        case 2:
                            //MOSTRAR LIBROS
                            _style.PrintOptionTitle("LIBROS DISPONIBLES\n"); 

                            break;
                        case 3:
                            //MOSTRAR PELÍCULAS
                            _style.PrintOptionTitle("PELÍCULAS DISPONIBLES\n"); 
                            //mostrar peliculas, y preguntar si se decide 
                            break;
                        case 4:
                            //HISTORIAL DEL USUARIO
                            _style.PrintOptionTitle("HISTORIAL DE VISUALIZACIÓN Y LECTURA\n"); 
                            //muestra el historial de todo lo que ha visto y leído (si hay, claro)
                            break;
                        case 5:
                            //VOLVER
                            _menu.DisplayMainMenu();
                            break;
                        default:
                            _style.PrintError($"\nLa opción {option} no está en el menú.\n");
                            break;
                    }
                }else {
                    _style.PrintError("\nInicio de sesión fallido. Comprueba que la contraseña o el correo sean correctos.\n");
                    _menu.DisplayMainMenu();
                }
                break;
            case 3:
                //SALIR
                exit = true;
                _menu.DisplayFarewell();
                break;
            default:
                _style.PrintError($"\nLa opción {option} no está en el menú.\n");
                break;
        }
    }catch (FormatException) {
        _style.PrintError($"\nError de formato. Debes introducir un carácter válido.\n");
    }
}