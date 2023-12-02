using System.Text.Json;
using LibraryApp.Models;

namespace LibraryApp.Data {

    public class LibraryRepository : ILibraryRepository {
        private Dictionary<string, User> _users = new Dictionary<string, User>();
        private Dictionary<string, Book> _books = new Dictionary<string, Book>();
        private Dictionary<string, Film> _films = new Dictionary<string, Film>();

        public LibraryRepository() {
            AddBooks();
            AddFilms();
        }

        private void AddBooks() {
            var booksToAdd = new List<Book> {
                new Book("El Diario de Greg 1: Un pringao total", "Jeff Kinney", 2008, 240, "Molino", true),
                new Book("Geronimo Stilton: En el Reino de la Fantasía", "Elisabetta Dami", 2005, 384, "Destino", true),
                new Book("Tom Gates: Excusas perfectas (y otras cosillas geniales)", "Liz Pichon", 2012, 352, "Bruño", true),
                new Book("Bajo la Misma Estrella", "John Green", 2014, 301, "Nube de Tinta", true),
                new Book("La Celestina", "Fernando de Rojas", 2013, 256, "Vicens Vives", true),
                new Book("La Bestia", "Carmen Mola", 2021, 544, "Planeta", true),
                new Book("Fuego y Sangre", "George R.R. Martin", 2018, 880, "Plaza & Janés", true),
                new Book("El Resplandor", "Stephen King", 2021, 656, "DeBols!llo", true),
                new Book("Los Juegos del Hambre", "Suzanne Collins", 2014, 400, "Molino", true)
            };
            foreach (var book in booksToAdd) {
                _books.Add(book.Title, book);
            }
        }

        private void AddFilms() {
            var filmsToAdd = new List<Film> {
                new Film("Yucatán", "Daniel Monzón", 2018, 130, "Comedia", true),
                new Film("Megalodón", "Jon Turteltaub", 2018, 113, "Acción", true),
                new Film("Cars", "John Lasseter", 2006, 116, "Comedia", true),
                new Film("Ocho Apellidos Vascos", "Emilio Martínez Lázaro", 2014, 98, "Comedia", true),
                new Film("Villaviciosa de al lado", "Nacho G. Velilla", 2016, 90, "Comedia", true),
                new Film("La Monja", "Corin Hardy", 2018, 96, "Terror", true),
                new Film("Transformers", "Michael Bay", 2007, 143, "Ciencia ficción", true),
                new Film("Jurassic World: Dominion", "Colin Trevorrow", 2022, 146, "Acción", true),
                new Film("Oppenheimer", "Christopher Nolan", 2023, 180, "Suspense", true),
                new Film("Fast and Furious X", "Louis Leterrier", 2023, 141, "Acción", true)
            };
            foreach (var film in filmsToAdd) {
                _films.Add(film.Title, film);
            }
        }

        //PARA VER EL CONTENIDO DE LOS DICCIONARIOS
        // public Dictionary<string, Book> GetBooksDictionary() {
        //     return _books;
        // }

        // public Dictionary<string, Film> GetFilmsDictionary() {
        //     return _films;
        // }









   //LIBROS
        // public void AddBooksToDictionary(Dictionary<string, Book> _books) {
        //     _books.Add();
        // }

        private string _folderPath = @"..\Data\DATA_USERS";

        // public LibraryRepository() {
        //     LoadDataFromJson();
        // }

        //OBTENER LAS CUENTAS (USUARIOS) QUE HAY EN EL DICCIONARIO (PRUEBA)
        public Dictionary<string, User> GetUsersDictionary() {
            return _users;
        }

        public User? GetAccountByEmail(string email) {
            _users.TryGetValue(email, out var user);
            return user;
        }
       
        public void AddAccount(User user) {
            User? existingUser = GetAccountByEmail(user.Email);
            if (existingUser == null) {
                _users[user.Email] = user;
                SaveUserToJson(user);
            }
        }

        public void SaveUserToJson(User user) {
            try{
                string _fileName = $"{user.Email}.json";
                string fullPath = Path.Combine(_folderPath, _fileName);
                Directory.CreateDirectory(_folderPath);
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(user, options);
                File.WriteAllText(fullPath, jsonString);
                Console.WriteLine($"Usuario {user.Email} serializado y guardado en {fullPath}");
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        //CONFLICTO: SI SALES DEL PROGRAMA, LAS CUENTAS QUE HAS CREADO SIGUEN ESTANDO, POR LO QUE SI VUELVES A METER EL MISMO CORREO

        // public void LoadDataFromJson() {
        //     try {
        //         string[] filePaths = Directory.GetFiles(_folderPath, "*.json");
        //         foreach (string filePath in filePaths) {
        //             string jsonString = File.ReadAllText(filePath);
        //             var options = new JsonSerializerOptions { WriteIndented = true };
        //             User user = JsonSerializer.Deserialize<User>(jsonString, options);
        //             _users[user.Email] = user;
        //             Console.WriteLine($"Usuario cargado desde {filePath}");
        //         }
        //     }catch (Exception e) {
        //         Console.WriteLine($"Error al cargar usuarios desde JSON: {e.Message}");
        //     }
        // }
    }

}