using LibraryApp.Data;

namespace LibraryApp.Business {
    public class LibraryService : ILibraryService {
        private readonly ILibraryRepository _repository;

        public LibraryService(ILibraryRepository repository) {
            _repository = repository;
        }


        /*HISTORIAL USUARIO*/
        public void SetCurrentUser(string email) {
            _repository.SetCurrentUser(email);
        }

        public void AddItemToHistory(string title) {
            _repository.AddItemToHistory(title);
        }

        public List<string[]> GetHistoryRows() {
            return _repository.GetHistory();
        }
        

        /*GESTION LIBROS Y PELICULAS*/
        public List<string[]> GetBooksRows() {
            var _booksData = _repository.GetBooksDictionary();
            List<string[]> bookRow = new List<string[]>();
            foreach (var book in _booksData.Values) {
                string[] row = { book.Title, book.Author, book.YearPublished.ToString(), book.Pages.ToString(), book.Publisher, book.Genre };
                bookRow.Add(row);
            }
            return bookRow;
        }

        public List<string[]> GetFilmsRows() {
            var _filmsData = _repository.GetFilmsDictionary();
            List<string[]> filmRow = new List<string[]>();
            foreach (var film in _filmsData.Values) {
                string[] row = { film.Title, film.Director, film.YearPublished.ToString(), film.DurationFormatted, film.Genre, film.RecommendedAge };
                filmRow.Add(row);
            }
            return filmRow;
        }

        public string? GetLinkByTitle(string title) {
            return _repository.GetAllLinks(title);
        }


        /*GESTION USUARIOS*/
        public bool CreateUser(string name, string lastname, string email, string password, int phoneNumber) {
            if (!_repository.EmailExists(email)) {
                _repository.AddUserToDictionary(name, lastname, email, password, phoneNumber);
                return true;
            }else {
                return false;
            }
        }

        public bool AuthenticateUser(string email, string password) {
            return _repository.VerifyLogin(email, password);
        }


        /*BUSCAR*/
        public bool SearchFunctionality(string title) {
            bool isTitleInLibrary = _repository.GetAllTitles().Contains(title);
            if (isTitleInLibrary) {
                return true;
            }else {
                return false;
            }
        }

    }

}