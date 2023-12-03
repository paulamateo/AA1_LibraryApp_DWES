using System.ComponentModel.DataAnnotations;
using LibraryApp.Business;

namespace LibraryApp.Presentation {
    public class Menu {

        Style _style = new Style();
        public void DisplayWelcome() { 
            _style.PrintInfo("BIBLIOTECA MULTIMEDIA 'NEXVERSE");
        }

        public void DisplayMainMenu() {
            _style.PrintMenu("1 - Crear cuenta\n2 - Iniciar sesión\n3 - Salir");
        }

        public void DisplaySecondMenu() {
            _style.PrintMenu("1 - Buscar\n2 - Mostrar libros disponibles\n3 - Mostrar películas disponibles\n4 - Historial del usuario\n5 - Volver");
        }

        public (string? name, string? lastname, string? email, string? password, int phoneNumber) DisplayPanelforCreateAccount() {
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
            return (name, lastname, email, password, phoneNumber);
        }

        public (string? email, string? password) DisplayPanelforLogin() {
            DisplayOptionTitle("INICIAR SESIÓN");
            Console.WriteLine("\nCorreo electrónico:");
            string? email = Console.ReadLine();
            Console.WriteLine("Contraseña:");
            string? password = Console.ReadLine();
            return (email, password);
        }

        public void DisplayPanelforActions(int? optionAction) {
            switch(optionAction) {
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
                    DisplayMainMenu();
                    break;
                default:
                    _style.PrintError($"\nLa opción {optionAction} no está en el menú.\n");
                    break;
                }
        }












        public void DisplayOptionTitle(string optionName) {
            _style.PrintOptionTitle($"{optionName}\nIntroduce los datos que se piden a continuación");   
        }




         public void DisplayFarewell() { 
            _style.PrintInfo("\n¡Hasta pronto!");
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


    }
}