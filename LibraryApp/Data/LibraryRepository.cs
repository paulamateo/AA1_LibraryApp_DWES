using System.Text.Json;
using LibraryApp.Models;

namespace LibraryApp.Data {
    public class LibraryRepository : ILibraryRepository {
        public static Dictionary<string, User> UsersAccount = new Dictionary<string, User>();
        private static readonly string folderUsers = "DATA_USERS";

        public static void SaveUserToJson(User user) {
            try {
                string folderPath = Path.Combine(folderUsers);
                string fileName = $"{user.Email}.json";
                string fullPath = Path.Combine(folderPath, fileName);
                Directory.CreateDirectory(folderPath);
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(user, options);
                File.WriteAllText(fullPath, jsonString);    
                Console.WriteLine($"Usuario guardado en: {fullPath}");
            } catch (Exception e) {
                Console.WriteLine($"Error al intentar guardar el usuario en JSON: {e.Message}");
            }
        }
        
    }

}