using System.Text.Json;
using LibraryApp.Models;

namespace LibraryApp.Data {
    public class LibraryRepository : ILibraryRepository {
        public static Dictionary<string, User> UsersAccount = new Dictionary<string, User>();

        private static readonly string folderUsers = "DATA_USERS";

        public static void SaveUserToJson(User user) {
            try {
                string fileName = $"{user.Email}.json";
                string fullPath = Path.Combine(folderUsers, fileName);
                Directory.CreateDirectory(folderUsers);
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(user, options);
                File.WriteAllText(fullPath, jsonString);    
            } catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
        
    }

}