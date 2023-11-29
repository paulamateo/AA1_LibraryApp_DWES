using LibraryApp.Business;

namespace LibraryApp.Presentation {
    public class Menu {

        public static void DisplayTitle() {
            Style.PrintTitle("BIBLIOTECA MULTIMEDIA 'El Almacén de Historias'");
        }

        public static void DisplayPrincipalMenu() {
            Style.PrintMenu("1 - Iniciar sesión\n2 - Crear cuenta\n3 - Salir");
        }

        public static void Login() {
            Style.PrintOptionTitle("INICIAR SESIÓN");
            Console.WriteLine("Correo electrónico:");
            string? email = Console.ReadLine();
            Console.WriteLine("Contraseña:");
            string? password = Console.ReadLine();
            
            bool accountHasBeenCreated = LibraryService.UserExists(email);
            if (accountHasBeenCreated) {
                Style.PrintSuccess($"¡Hola de nuevo!");
                DisplaySecondMenu();
            }else {
                Style.PrintError("Tu correo electrónico no está asociado a ninguna cuenta.\n");
                DisplayPrincipalMenu();
            }
        }

        public static void SignUp() {
            Style.PrintOptionTitle("CREAR CUENTA");
            Console.WriteLine("Nombre:");
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
            bool accountCreated = LibraryService.AddUser(name, lastname, email, password, phoneNumber);
            if (accountCreated) {
                Style.PrintSuccess("Cuenta creada exitosamente.\n");
                DisplaySecondMenu();
            } else{
                Style.PrintError("Este correo electrónico ya está asociado a una cuenta.\n");
            }
        }

        public static void DisplaySecondMenu() {
            Console.WriteLine("1 - Buscar libro");
            Console.WriteLine("2 - Devolver libro");
            Console.WriteLine("3 - Buscar película");
            Console.WriteLine("4 - Devolver película");
            Console.WriteLine("5 - Volver");
        }
    }
}