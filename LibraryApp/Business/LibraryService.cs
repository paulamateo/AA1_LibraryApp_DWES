using System.Reflection.Metadata;
using LibraryApp.Data;
using LibraryApp.Models;

namespace LibraryApp.Business {
    public class LibraryService : ILibraryService {

public static void ViewUserDictionary() {
    Console.WriteLine("CONTENIDO DEL DICCIONARIO DE USUARIOS:");

    foreach (var kvp in LibraryRepository.UsersAccount) {
        Console.WriteLine($"Email: {kvp.Key}");
        Console.WriteLine($"Nombre: {kvp.Value.Name}");
        Console.WriteLine($"Apellidos: {kvp.Value.Lastname}");
        Console.WriteLine($"Teléfono: {kvp.Value.PhoneNumber}");
        Console.WriteLine("------------------------------");
    }

    Console.WriteLine("Fin del contenido del diccionario.\n");
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