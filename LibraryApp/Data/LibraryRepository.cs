using System.Text.Json;
using LibraryApp.Models;

namespace LibraryApp.Data {

    public class LibraryRepository : ILibraryRepository {
        private Dictionary<string, User> _users = new Dictionary<string, User>();
        private Dictionary<string, Book> _books = new Dictionary<string, Book>();
        private Dictionary<string, Film> _films = new Dictionary<string, Film>();
        private string _folderPath = @"..\Data\JSON\DATA_USERS";
        private string _folderPathBooksFilms = @"..\Data\JSON";
        private User? _currentUser;

        public LibraryRepository() {
            AddBooks();
            AddFilms();
        }


        /*HISTORIAL USUARIO*/
        public void SetCurrentUser(string email) {
            if (_users.TryGetValue(email, out var user)) {
                _currentUser = user;
            }
        }

        public void AddItemToHistory(string title) {
            if (_currentUser != null) {
                string[] item = new string[] { DateTime.Now.ToString(), title };
                _currentUser.History.Add(item);
            }
        }

        public List<string[]> GetHistory() {
            return _currentUser?.History ?? new List<string[]>();
        }


        /*GESTION LIBROS Y PELICULAS*/
        private void AddBooks() {
            var booksToAdd = new List<Book> {
                new Book("Los Juegos del Hambre", "Suzanne Collins", 2014, 400, "Molino", "Aventuras"),
                new Book("La Celestina", "Fernando de Rojas", 2013, 256, "Vicens Vives", "Drama"),
                new Book("Bajo la Misma Estrella", "John Green", 2014, 301, "Nube de Tinta", "Drama"),
                new Book("Tan Poca Vida", "Hanya Yanagihara", 2016, 1008, "Lumen", "Drama"),
                new Book("Fuego y Sangre", "George R.R. Martin", 2023, 888, "DeBolsillo", "Drama"),
                new Book("Las Aventuras de Tom Sawyer", "Mark Twain", 2020, 32, "Susaeta", "Humor"),
                new Book("El Diario de Greg 1: Un pringao total", "Jeff Kinney", 2008, 240, "Molino", "Humor"),
                new Book("Las aventuras de Sherlock Holmes", "Arthur Conan Doyle", 2022, 384, "Booket", "Misterio"),
                new Book("La Chica del Tren", "Paula Hawkins", 2018, 496, "Booket", "Misterio"),
                new Book("El Resplandor", "Stephen King", 2021, 656, "DeBolsillo", "Terror"),
                new Book("Jaque al Psicoanalista", "John Katzenbach", 2023, 440, "Booket", "Thriller"),
                new Book("La Bestia", "Carmen Mola", 2021, 544, "Planeta", "Thriller")
            };
            foreach (var book in booksToAdd) {
                _books.Add(book.Title, book);
            }
            SaveBooksToJson(booksToAdd);
        }

        private void AddFilms() {
            var filmsToAdd = new List<Film> {
                new Film("Spirit: El Corcel Indomable", "Kelly Asbury", 2002, 83, "Aventura", "Todas las edades"),
                new Film("Jurassic World: Dominion", "Colin Trevorrow", 2022, 146, "Aventura", "12"),
                new Film("Fast and Furious X", "Louis Leterrier", 2023, 141, "Aventura", "12"),
                new Film("Cars", "John Lasseter", 2006, 116, "Comedia", "Todas las edades"),
                new Film("Ocho Apellidos Vascos", "Borja Cobeaga", 2014, 98, "Comedia", "12"),
                new Film("Villaviciosa de al lado", "Nacho G. Velilla", 2016, 90, "Comedia", "12"),
                new Film("Wonder", "Stephen Chbosky", 2017, 113, "Drama", "10"),
                new Film("Los Renglones Torcidos de Dios", "Oriol Paulo", 2022, 154, "Drama", "12"),
                new Film("Elvis", "Baz Luhrmann", 2022, 159, "Musical", "12"),
                new Film("Oppenheimer", "Christopher Nolan", 2023, 180, "Suspense", "16"),
                new Film("La Monja", "Corin Hardy", 2018, 96, "Terror", "16"),
                new Film("Insidious", "James Wan", 2010, 102, "Terror", "16")
            };
            foreach (var film in filmsToAdd) {
                _films.Add(film.Title, film);
            }
            SaveFilmsToJson(filmsToAdd);
        }

        public Dictionary<string, Book> GetBooksDictionary() {
            return _books;
        }
        public Dictionary<string, Film> GetFilmsDictionary() {
            return _films;
        }
        public List<string> GetAllTitles() {
            List<string> titles = new List<string>();
            foreach (var book in _books) {
                titles.Add(book.Value.Title);
            }
            foreach (var film in _films) {
                titles.Add(film.Value.Title);
            }
            return titles;
        }


        /*GESTION USUARIOS*/
        public void AddUserToDictionary(string name, string lastname, string email, string password, int phoneNumber) {
            User _user = new User(name, lastname, email, password, phoneNumber);
            _users[_user.Email] = _user;
            SaveUserToJson(_user);
        }

        public bool EmailExists(string email) {
            return _users.ContainsKey(email);
        }

        public bool VerifyLogin(string email, string password) {
            if (_users.TryGetValue(email, out var user)) {
                return user.Password == password;
            }else {
                return false;
            }
        }


        /*JSON*/
        public void SaveBooksToJson(List<Book> _booksData) {
            string _fileNameBooks = "DATA_BOOKS";
            string fullPathB = Path.Combine(_folderPathBooksFilms, _fileNameBooks);
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonBooks = JsonSerializer.Serialize(_booksData, options);
            File.WriteAllText(fullPathB, jsonBooks);
        }


        public void SaveFilmsToJson(List<Film> _filmsData) {
            string _fileNameFilms = "DATA_FILMS";
            string fullPathF = Path.Combine(_folderPathBooksFilms, _fileNameFilms);
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonFilms = JsonSerializer.Serialize(_filmsData, options);
            File.WriteAllText(fullPathF, jsonFilms);
            File.WriteAllText(fullPathF, jsonFilms);
        }

        public void SaveUserToJson(User user) {
            try{
                string _fileName = $"{user.Email}.json";
                string fullPath = Path.Combine(_folderPath, _fileName);
                Directory.CreateDirectory(_folderPath);
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(user, options);
                File.WriteAllText(fullPath, jsonString);
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

    }
}