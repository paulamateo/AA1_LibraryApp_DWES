namespace LibraryApp.Models;

public class Book {
    public string? Title { get; set; }
    public string? Author { get; set; }
    public int YearPublished { get; set; }
    public int Pages { get; set; }
    public string? Publisher { get; set; }
    public bool IsAvailable { get; set; }
    //historial de un libro

    public Book(string title, string author, int yearPublished, int pages, string publisher, bool isAvailable) {
        Title = title;
        Author = author;
        YearPublished = yearPublished;
        Pages = pages;
        Publisher = publisher;
        IsAvailable = isAvailable;
    }
}