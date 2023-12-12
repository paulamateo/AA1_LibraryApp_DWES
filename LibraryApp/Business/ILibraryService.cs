using LibraryApp.Data;

namespace LibraryApp.Business {
    public interface ILibraryService {
        List<string[]> GetBooksRows();
        List<string[]> GetFilmsRows();
        bool CreateUser(string name, string lastname, string email, string password, int phoneNumber);
        bool AuthenticateUser(string email, string password);
        bool SearchTitle(string title);
        bool SearchAuthDir(string authDir);

    }
}
