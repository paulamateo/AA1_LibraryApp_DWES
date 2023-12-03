namespace LibraryApp.Models;

public class Book {
    public string Title { get; }
    public string Author { get; }
    public int YearPublished { get; }
    public int Pages { get; }
    public string Publisher { get; }
    public string Genre { get; }

    public Book(string title, string author, int yearPublished, int pages, string publisher, string genre) {
        Title = title;
        Author = author;
        YearPublished = yearPublished;
        Pages = pages;
        Publisher = publisher;
        Genre = genre;
    }
}