using System.Reflection.Metadata;
using LibraryApp.Data;
using LibraryApp.Models;

namespace LibraryApp.Business {
    public class LibraryService : ILibraryService {

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

        public static bool UserExists(string email) {
            if (LibraryRepository.UsersAccount.ContainsKey(email)) {
                return true;
            }else {
                return false;
            }
        }

    }
}