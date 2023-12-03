using LibraryApp.Data;

namespace LibraryApp.Business {
    public interface ILibraryService {
        void DisplayBooks();
        void DisplayFilms();
        bool CreateNewUser(string name, string lastname, string email, string password, int phoneNumber);
        bool AuthenticateUser(string email, string password);

    }
}
