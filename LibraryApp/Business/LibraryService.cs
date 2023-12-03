using LibraryApp.Data;
// using LibraryApp.Models;

namespace LibraryApp.Business {
    public class LibraryService : ILibraryService {

        private readonly ILibraryRepository _repository;

        public LibraryService(ILibraryRepository repository) {
            _repository = repository;
        }

        public Dictionary<string, Book> GetBooks() {
            return _repository.GetBooksDictionary();
        }


  


        public void DisplayFilms() {
            Dictionary<string, Film> _filmsDictionary = _repository.GetFilmsDictionary();

            foreach (var film in _filmsDictionary.Values) {
                Console.WriteLine($"Título: {film.Title}");
            }
        }
    


        //CREAR USUARIO
        public bool CreateNewUser(string name, string lastname, string email, string password, int phoneNumber) {
            User? existingEmailAccount = _repository.GetAccountByEmail(email);
            if (existingEmailAccount == null) {
                User user = new User(name, lastname, email, password, phoneNumber);
                _repository.AddAccount(user);
                return true;
            }else {
                return false;
            }
        }

        //VER SI EL CORREO ELECTRONICO ESTÁ EN EL DICCIONARIO, Y SI ADEMAS EL CORREO ELECTRONICO COINCIDE CON LA CONTRASEÑA
        public bool AuthenticateUser(string email, string password) {
            User? existingEmailAccount = _repository.GetAccountByEmail(email);
            if (existingEmailAccount != null && existingEmailAccount.Password == password) {
                return true;
            } else {
                return false;
            }
        }

    }

}