namespace LibraryApp.Models;

public class Book {
    public string Title { get; }
    public string Author { get; }
    public int YearPublished { get; }
    public int Pages { get; }
    public string Publisher { get; }
    public string Genre { get; }
    public string Link { get; }

    public Book(string title, string author, int yearPublished, int pages, string publisher, string genre, string link) {
        Title = title;
        Author = author;
        YearPublished = yearPublished;
        Pages = pages;
        Publisher = publisher;
        Genre = genre;
        Link = link;
    }
}