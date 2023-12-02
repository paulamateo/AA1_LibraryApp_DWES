using LibraryApp.Business;

namespace LibraryApp.Presentation {
    public class Menu {

        Style _style = new Style();
        public void DisplayWelcome() { 
            _style.PrintInfo("BIBLIOTECA MULTIMEDIA 'El Almacén de Historias'\n");
        }

        public void DisplayPrincipalMenu() {
            _style.PrintMenu("1 - Crear cuenta\n2 - Iniciar sesión\n3 - Salir");
        }

        // public void DisplayPaneltoCreateAccount() {
        //     DisplayOptionTitle("CREAR CUENTA");
        //     Console.WriteLine("\nNombre:");
        //     string? name = Console.ReadLine();
        //     Console.WriteLine("Apellidos:");
        //     string? lastname = Console.ReadLine();
        //     Console.WriteLine("Correo electrónico");
        //     string? email = Console.ReadLine();
        //     Console.WriteLine("Teléfono:");
        //     int phoneNumber = Convert.ToInt32(Console.ReadLine());
        //     Console.WriteLine("Contraseña:");
        //     string? password = Console.ReadLine();
        //     Console.WriteLine("Confirmar contraseña:");
        //     string? secondPassword = Console.ReadLine();  
        // }

        public (string? Name, string? Lastname, string? Email, string? Password, int PhoneNumber) DisplayPaneltoCreateAccount() {
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
            Console.WriteLine("Confirmar contraseña:");
            string? secondPassword = Console.ReadLine();
            return (name, lastname, email, password, phoneNumber);
        }

        public void AccountIsCreated(bool userCreated) {
            if (userCreated) {
                _style.PrintSuccess("\nCuenta creada exitosamente.\n");
                DisplaySecondMenu();
            }else {
                _style.PrintError("\nEl correo electrónico ya está asociado a una cuenta existente.\n");
                DisplayPrincipalMenu();
            }
        }











        public void DisplayOptionTitle(string optionName) {
            _style.PrintOptionTitle($"{optionName}\nIntroduce los datos que se piden a continuación");   
        }




         public void DisplayFarewell() { 
            _style.PrintInfo("\n¡Hasta pronto!");
        }




        public void DisplaySecondMenu() {
            _style.PrintMenu("1 - Buscar\n2 - Devolver\n3 - Mostrar información de tu cuenta\n4 - Volver");
        }

        public void OptionSecondMenu(int option) {
            switch(option) {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    DisplayInfoUser();
                    break;
                case 4:
                    // DisplayPrincipalMenu();
                    break;
                default:
                _style.PrintError($"La opción {option} no está en el menú");
                    break;
                
            }
        }


        public static void DisplayInfoUser() {
            //MÉTODO QUE ME VA A DECIR LOS LIBROS/PELIS QUE HE COGIDO, QUÉ FECHA, TIEMPO, ETC. Y SI LOS HE DEVUELTO O NO
        }



        //SIGN UP


        // //LOGIN
        // public static void AccountExists(bool isAuthenticated) {
        //     if(isAuthenticated) {
        //         DisplaySecondMenu();
        //     }else {
        //         Style.PrintError("\nInicio de sesión fallido. Comprueba que la contraseña o el correo sean correctos.\n");
        //         DisplayPrincipalMenu();
        //     }
        // }

    }
}