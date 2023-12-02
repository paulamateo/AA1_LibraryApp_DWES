using System.Text.Json;
using LibraryApp.Models;

namespace LibraryApp.Data {

    public class LibraryRepository : ILibraryRepository {
        private Dictionary<string, User> _users = new Dictionary<string, User>();
        private string _folderPath = @"..\Data\DATA_USERS";

        // public LibraryRepository() {
        //     LoadDataFromJson();
        // }

        //OBTENER LAS CUENTAS (USUARIOS) QUE HAY EN EL DICCIONARIO (PRUEBA)
        public Dictionary<string, User> GetUsersDictionary() {
            return _users;
        }

        public User? GetAccountByEmail(string email) {
            _users.TryGetValue(email, out var user);
            return user;
        }
       
        public void AddAccount(User user) {
            User? existingUser = GetAccountByEmail(user.Email);
            if (existingUser == null) {
                _users[user.Email] = user;
                SaveUserToJson(user);
            }
        }

        public void SaveUserToJson(User user) {
            try{
                string _fileName = $"{user.Email}.json";
                string fullPath = Path.Combine(_folderPath, _fileName);
                Directory.CreateDirectory(_folderPath);
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(user, options);
                File.WriteAllText(fullPath, jsonString);
                Console.WriteLine($"Usuario {user.Email} serializado y guardado en {fullPath}");
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        //CONFLICTO: SI SALES DEL PROGRAMA, LAS CUENTAS QUE HAS CREADO SIGUEN ESTANDO, POR LO QUE SI VUELVES A METER EL MISMO CORREO

        // public void LoadDataFromJson() {
        //     try {
        //         string[] filePaths = Directory.GetFiles(_folderPath, "*.json");
        //         foreach (string filePath in filePaths) {
        //             string jsonString = File.ReadAllText(filePath);
        //             var options = new JsonSerializerOptions { WriteIndented = true };
        //             User user = JsonSerializer.Deserialize<User>(jsonString, options);
        //             _users[user.Email] = user;
        //             Console.WriteLine($"Usuario cargado desde {filePath}");
        //         }
        //     }catch (Exception e) {
        //         Console.WriteLine($"Error al cargar usuarios desde JSON: {e.Message}");
        //     }
        // }
    }

}