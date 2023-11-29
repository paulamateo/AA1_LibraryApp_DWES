using System.Reflection.Metadata;
using LibraryApp.Data;
using LibraryApp.Models;

namespace LibraryApp.Business {
    public class LibraryService : ILibraryService {

        public static void ViewUserDictionary() {
            Console.WriteLine("CONTENIDO DEL DICCIONARIO DE USUARIOS:");

            foreach (var item in LibraryRepository.UsersAccount) {
                Console.WriteLine($"Email: {item.Key}");
                Console.WriteLine($"Nombre: {item.Value.Name}");
                Console.WriteLine($"Apellidos: {item.Value.Lastname}");
                Console.WriteLine($"Teléfono: {item.Value.PhoneNumber}");
                Console.WriteLine("------------------------------");
            }
        }

        public static bool AddUser(string name, string lastname, string email, string password, int phoneNumber) {
            if (LibraryRepository.UsersAccount.ContainsKey(email)) {
                return false; 
            }else {
                User newUser = new User(name, lastname, email, password, phoneNumber);
                LibraryRepository.UsersAccount.Add(email, newUser);
                LibraryRepository.SaveUserToJson(newUser);
                return true;
            }
        }
    }
}