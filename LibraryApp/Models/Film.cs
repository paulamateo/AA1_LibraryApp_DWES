namespace LibraryApp.Models;

public class Film {
    public string? Title { get; set; }
    public string? Director { get; set; }
    public int YearPublished { get; set; }
    public TimeSpan Length { get; set; }
    public string? Genre { get; set; }
    public bool IsAvailable { get; set; }

    public Film(string title, string director, int yearPublished, TimeSpan length, string genre, bool isAvailable) {
        Title = title;
        Director = director;
        YearPublished = yearPublished;
        Length = length;
        Genre = genre;
        IsAvailable = isAvailable;
    }
}