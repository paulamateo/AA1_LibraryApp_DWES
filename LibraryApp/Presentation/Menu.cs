using LibraryApp.Business;

namespace LibraryApp.Presentation {
    public class Menu {

        public static void Title() {
            Console.WriteLine("BIBLIOTECA MULTIMEDIA 'El Almacén de Historias'");
            Console.WriteLine("¡Bienvenido!");
        }
        
        public static void DisplayPrincipalMenu() {
            Console.WriteLine("1 - Iniciar sesión");
            Console.WriteLine("2 - Crear cuenta");
            Console.WriteLine("3 - Salir");
        }

        public static void Login() {
            Console.WriteLine("Correo electrónico:");
            Console.WriteLine("Contraseña:");
        }

        public static void CreateNewAccount() {
            Console.WriteLine("CREAR CUENTA");
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
                Style.PrintGood("Cuenta creada exitosamente.\n");
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