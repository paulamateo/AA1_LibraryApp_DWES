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
            Console.WriteLine("Correo electrónico:");
            Console.WriteLine("Contraseña:");
        }

        public static void CreateNewAccount() {
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
            bool accountCreated = LibraryService.AddUser(name, lastname, email, password, phoneNumber);
            if (accountCreated) {
                Style.PrintSuccess("Cuenta creada exitosamente.\n");
            } else{
                Style.PrintError("Este correo electrónico ya está asociado a una cuenta.\n");
            }
        }

        public void DisplaySecondMenu(string name) {
            Console.WriteLine($"¡Hola de nuevo, {name}!");
            Console.WriteLine("1 - Buscar libro");
            Console.WriteLine("2 - Devolver libro");
            Console.WriteLine("3 - Buscar película");
            Console.WriteLine("4 - Devolver película");
            Console.WriteLine("5 - Volver");
        }
    }
}