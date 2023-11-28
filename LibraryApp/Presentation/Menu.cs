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

        public void Login() {
            Console.WriteLine("Correo electrónico:");
            Console.WriteLine("Contraseña:");
        }

        public void SignUp() {
            Console.WriteLine("Nombre:");
            Console.WriteLine("Apellidos:");
            Console.WriteLine("Correo electrónico");
            Console.WriteLine("Teléfono:");
            Console.WriteLine("Contraseña:");
            Console.WriteLine("Confirmar contraseña:");
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