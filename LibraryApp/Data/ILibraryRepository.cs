using LibraryApp.Models;

namespace LibraryApp.Data {
    public interface ILibraryRepository {
        void AddAccount(User user);

        Dictionary<string, User> GetUsersDictionary();

        Dictionary<string, Book> GetBooksDictionary();

        Dictionary<string, Film> GetFilmsDictionary();

        User? GetAccountByEmail(string email);

    }

}