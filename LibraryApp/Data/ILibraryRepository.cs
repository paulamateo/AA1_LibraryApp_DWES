using LibraryApp.Models;

namespace LibraryApp.Data {
    public interface ILibraryRepository {
        void AddAccount(User user);

        Dictionary<string, User> GetUsersDictionary();

        User? GetAccountByEmail(string email);

    }

}