using LibraryApp.Business;

namespace LibraryApp.Presentation {
    public class Menu {

        public static void DisplayWelcome() { 
            Style.PrintInfo("BIBLIOTECA MULTIMEDIA 'El Almacén de Historias'\n");
        }

        public static void DisplayFarewell() { 
            Style.PrintInfo("\n¡Hasta pronto!");
        }

        public static void DisplayOptionTitle(string optionName) {
            Style.PrintOptionTitle($"{optionName}\nIntroduce los datos que se piden a continuación");   
        }

        public static void DisplayPrincipalMenu() {
            Style.PrintMenu("1 - Iniciar sesión\n2 - Crear cuenta\n3 - Salir");
        }

        public static void DisplaySecondMenu() {
            Style.PrintMenu("1 - Buscar\n2 - Devolver\n3 - Mostrar información de tu cuenta\n4 - Volver");
        }

        public static void OptionSecondMenu(int option) {
            switch(option) {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    DisplayInfoUser();
                    break;
                case 4:
                    DisplayPrincipalMenu();
                    break;
                default:
                Style.PrintError($"La opción {option} no está en el menú");
                    break;
                
            }
        }


        public static void DisplayInfoUser() {
            //MÉTODO QUE ME VA A DECIR LOS LIBROS/PELIS QUE HE COGIDO, QUÉ FECHA, TIEMPO, ETC. Y SI LOS HE DEVUELTO O NO
        }

        //SIGN UP
        public static void AccountIsCreated(bool userCreated) {
            if (userCreated) {
                Style.PrintSuccess("\nCuenta creada exitosamente.\n");
                DisplaySecondMenu();
            }else {
                Style.PrintError("\nEl correo electrónico ya está asociado a una cuenta existente.\n");
                DisplayPrincipalMenu();
            }
        }


        //LOGIN
        public static void AccountExists(bool isAuthenticated) {
            if(isAuthenticated) {
                DisplaySecondMenu();
            }else {
                Style.PrintError("\nInicio de sesión fallido. Comprueba que la contraseña o el correo sean correctos.\n");
                DisplayPrincipalMenu();
            }
        }

    }
}