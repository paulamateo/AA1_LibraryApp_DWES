namespace LibraryApp.Models;

public class User {
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int PhoneNumber { get; set; }
    public int userNumber = 1;
    public string userAccountNumber { get; }
    
    public List<string[]> BooksHistory { get; set; } = new List<string[]>();
    public List<string[]> FilmsHistory { get; set; } = new List<string[]>();


    public User(string name, string lastname, string email, string password, int phoneNumber) {
        Name = name;
        Lastname = lastname;
        Email = email;
        Password = password;
        PhoneNumber = phoneNumber;
        userAccountNumber = userNumber.ToString();
        userNumber++;
    }

    public void AddBookToHistory(string title, string author, string publication, string genre) {
        string[] bookItem = new string[] { DateTime.Now.ToString(), title, author, publication, genre };
        BooksHistory.Add(bookItem);
    }

    public void AddFilmToHistory(string title, string director, string publication, string genre) {
        string[] filmItem = new string[] { DateTime.Now.ToString(), title, director, publication, genre };
        FilmsHistory.Add(filmItem);
    }

}