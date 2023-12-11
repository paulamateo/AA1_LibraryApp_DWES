using System.Text.Json;
using LibraryApp.Models;

namespace LibraryApp.Data {

    public class LibraryRepository : ILibraryRepository {
        private Dictionary<string, User> _users = new Dictionary<string, User>();
        private Dictionary<string, Book> _books = new Dictionary<string, Book>();
        private Dictionary<string, Film> _films = new Dictionary<string, Film>();
        private string _folderPath = @"..\Data\JSON";
        private string _folderPathUsers = @"..\Data\JSON\DATA_USERS\";
        private string? _fileNameUsers;
        private User? _currentUser;

        public LibraryRepository() {
            AddBooks();
            SaveBooksToJson();
            AddFilms();
            SaveFilmsToJson();

            AppDomain.CurrentDomain.ProcessExit += CleanFiles;
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
                SaveUserToJson(_currentUser);
            }
        }

        public List<string[]> GetHistory() {
            return _currentUser?.History ?? new List<string[]>();
        }


        /*GESTION LIBROS Y PELICULAS*/
        private void AddBooks() {
            var booksToAdd = new List<Book> {
                new Book("Los Juegos del Hambre", "Suzanne Collins", 2014, 400, "Molino", "AVENTURAS", "https://drive.google.com/file/d/1aW99Etur-yHDY3v8pV79wl9ZtV-aF3Px/view?usp=drive_link"),
                new Book("La Celestina", "Fernando de Rojas", 2013, 256, "Vicens Vives", "DRAMA", "https://drive.google.com/file/d/1l5oEj7LhsfqdPZw_hggNSibjWq5KxmI6/view?usp=drive_link"),
                new Book("Bajo la Misma Estrella", "John Green", 2014, 301, "Nube de Tinta", "DRAMA", "https://drive.google.com/file/d/1x8FFiy36D4wtH7IDUhjMMNHWdd9MwTN-/view?usp=drive_link"),
                new Book("Tan Poca Vida", "Hanya Yanagihara", 2016, 1008, "Lumen", "DRAMA", "https://drive.google.com/file/d/1DTWPR8gpwJDPxQq7Y_2V5dLCgjhE4QhX/view?usp=drive_link"),
                new Book("Fuego y Sangre", "George R.R. Martin", 2023, 888, "DeBolsillo", "DRAMA", "https://drive.google.com/file/d/1LeU5IXzPQbRxqSb6NDqEI6nxu-7hFcth/view?usp=drive_link"),
                new Book("Las Aventuras de Tom Sawyer", "Mark Twain", 2020, 32, "Susaeta", "HUMOR", "https://drive.google.com/file/d/1xtuzcFqFddiHrkqK8kdNRkaXgPHS7pIQ/view?usp=drive_link"),
                new Book("El Diario de Greg 1: Un pringao total", "Jeff Kinney", 2008, 240, "MOLINO", "Humor", "https://drive.google.com/file/d/173yMfXNeasMYvhyzKUByF2I0dSn1k8p_/view?usp=drive_link"),
                new Book("Las Aventuras de Sherlock Holmes", "Arthur Conan Doyle", 2022, 384, "Booket", "MISTERIO", "https://drive.google.com/file/d/1GkYmFYweyz1yTEQ1DgLTLQmBFZJim7XU/view?usp=drive_link"),
                new Book("La Chica del Tren", "Paula Hawkins", 2018, 496, "Booket", "MISTERIO", "https://drive.google.com/file/d/18z3ZXaCT9goVrVzgPJZFu1Qb_q1TjXYE/view?usp=drive_link"),
                new Book("La Novia Gitana", "Carmen Mola", 2018, 408, "Alfaguara", "MISTERIO", "https://drive.google.com/file/d/1anthPexrabbfz3P6YkP5fK7qTSHdunSM/view?usp=drive_link"),
                new Book("Jaque al Psicoanalista", "John Katzenbach", 2023, 440, "Booket", "THRILLER", "https://drive.google.com/file/d/1DMnCjpiWOyRhQ88HqOWjWsi7FR3ej_AW/view?usp=drive_link")
            };
            foreach (var book in booksToAdd) {
                _books.Add(book.Title, book);
            }
        }

        private void AddFilms() {
            var filmsToAdd = new List<Film> {
                new Film("Dentro del Titanic", "Jeff Holland", 1999, 50, "DOCUMENTAL", "12", "https://drive.google.com/file/d/1XV_5uuLyi-filxVM42ObG_QMsDuogErr/view?usp=drive_link"),
                new Film("Fast and Furious 8", "F. Gary Gray", 2017, 148, "AVENTURA", "12", "https://drive.google.com/file/d/1Mmpkwd-5yQoUOma0i6_b3Y5QuX5pfN3u/view?usp=drive_link"),
                new Film("Fast and Furious 9", "Justin Lin", 2021, 150, "AVENTURA", "12", "https://drive.google.com/file/d/1jg3k9W-hT1SYzjpg9p0oDsCyMgKmFNWk/view?usp=drive_link"),
                new Film("Harry Potter y la Piedra Filosofal", "Chris Columbus", 2001, 159, "AVENTURA", "Todas las edades", "https://drive.google.com/file/d/1WojFcGeoUH-5YgKEJR5C9Mez1Nesy7AW/view?usp=drive_link"),
                new Film("Malas madres", "Jon Lucas", 2016, 100, "COMEDIA", "12", "https://drive.google.com/file/d/1NTKgDbH14dB3RjzRqAwmcAuIVHdGO27w/view?usp=drive_link"),
                new Film("Oceans 8", "Gary Ross", 2018, 110, "COMEDIA", "12", "https://drive.google.com/file/d/19XTM3-j6ZnYtrcB6nsTqW7dfDozVyc3a/view?usp=drive_link"),
                new Film("Ocho Apellidos Catalanes", "Emilio M.L.", 2015, 99, "COMEDIA", "7", "https://drive.google.com/file/d/1NwPnqjkUODcLf1A4u-RMHd6sBXH2S9Kl/view?usp=drive_link"),
                new Film("Ocho Apellidos Vascos", "Emilio M.L.", 2014, 98, " COMEDIA", "7", "https://drive.google.com/file/d/14QJ3gyql7a4xpS9vKi1Vv2h850_CAs-c/view?usp=drive_link"),
                new Film("Steve Jobs", "Danny Boyle", 2015, 122, "DOCUMENTAL", "7", "https://drive.google.com/file/d/1OnQSjJYRXRCBzJno3axJ77WhLerpyrBE/view?usp=drive_link"),
                new Film("Top Gun Maverick", "Joseph Kosinski", 2022, 130, "DRAMA", "13", "https://drive.google.com/file/d/1_8ENnngk9g6baym1Z8P9VEw0a2Moco5t/view?usp=drive_link"),
                new Film("Villaviciosa de al lado", "Nacho G. Velilla", 2016, 90, "COMEDIA", "12", "https://drive.google.com/file/d/1l_54cRw8nS7CY49bXUcUZSkz4wWFjVEP/view?usp=drive_link")
            };
            foreach (var film in filmsToAdd) {
                _films.Add(film.Title, film);
            }
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

        public string? GetAllLinks(string title) {
            if (_books.ContainsKey(title)) {
                return _books[title].Link;
            }else if (_films.ContainsKey(title)) {
                return _films[title].Link;
            }
            return null;
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
        private void SaveUserToJson(User user) {
            try {
                _fileNameUsers = $"{user.Email}.json";
                string _fullPath = Path.Combine(_folderPathUsers, _fileNameUsers);
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(user, options);
                File.WriteAllText(_fullPath, jsonString);
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        private void CleanFiles(object? sender, EventArgs e) {
            try {
                string _fullPath = Path.Combine(_folderPathUsers, _fileNameUsers);
                File.Delete(_fullPath);
            }catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }   

        private void SaveBooksToJson() {
            try {
                string _fileNameBooks = "DATA_BOOKS.json";
                string _fullPath = Path.Combine(_folderPath, _fileNameBooks);
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(_books.Values, options);
                File.WriteAllText(_fullPath, jsonString);
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        private void SaveFilmsToJson() {
            try {
                string _fileNameFilms = "DATA_FILMS.json";
                string _fullPath = Path.Combine(_folderPath, _fileNameFilms);
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(_films, options);
                File.WriteAllText(_fullPath, jsonString);
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

    }
}