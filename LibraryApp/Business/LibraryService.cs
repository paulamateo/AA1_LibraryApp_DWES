using LibraryApp.Data;
using LibraryApp.Models;

namespace LibraryApp.Business {
    public class LibraryService : ILibraryService {

        private readonly ILibraryRepository _repository;

        public LibraryService(ILibraryRepository repository) {
            _repository = repository;
        }

        
        // public void DisplayBooks() {
        //     Dictionary<string, Film> filmsDictionary = _repository.GetFilmsDictionary();

        //     Console.WriteLine("Contenido del diccionario:");
        //     foreach (var film in filmsDictionary.Values) {
        //         Console.WriteLine($"Título: {film.Title}, Duración: {film.DurationFormatted}");
        //     }
        // }
    


        //LISTAR CUENTAS CREADAS POR USUARIOS
        public void DisplayUsers() {
            Dictionary<string, User> usersDictionary = _repository.GetUsersDictionary();

            Console.WriteLine("Contenido del diccionario:");
            foreach (var user in usersDictionary.Values) {
                Console.WriteLine($"Email: {user.Email}, Nombre: {user.Name}, Apellido: {user.Lastname}, Teléfono: {user.PhoneNumber}");
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