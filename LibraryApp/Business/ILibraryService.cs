using LibraryApp.Data;

namespace LibraryApp.Business {
    public interface ILibraryService {
        List<string[]> GetBooksRows();
        List<string[]> GetFilmsRows();
        bool CreateUser(string name, string lastname, string email, string password, int phoneNumber);
        bool AuthenticateUser(string email, string password);
        bool SearchFunctionality(string title);
        void AddItemToHistory(string title);
        List<string[]> GetHistoryRows();
        void SetCurrentUser(string email);

    }
}
