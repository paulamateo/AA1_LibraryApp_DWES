using LibraryApp.Models;

namespace LibraryApp.Data {
    public interface ILibraryRepository {
        Dictionary<string, Book> GetBooksDictionary();
        Dictionary<string, Film> GetFilmsDictionary();
        void AddUserToDictionary(string name, string lastname, string email, string password, int phoneNumber);
        bool EmailExists(string email);
        bool VerifyLogin(string email, string password);
        List<string> GetAllTitles();
        void AddItemToHistory(string title);
        List<string[]> GetHistory();
        void SetCurrentUser(string email);

        // void SaveUserToJson(User user);
        // void SaveFilmsToJson(List<Film> _filmsData);
        // void SaveBooksToJson(List<Book> _booksData);

    }

}