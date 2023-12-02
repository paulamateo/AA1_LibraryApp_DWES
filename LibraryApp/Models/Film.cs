namespace LibraryApp.Models;

public class Film {

    public string Title { get; set; }
    public string Director { get; set; }
    public int YearPublished { get; set; }
    public int DurationInMinutes { get; set; }
    public string Genre { get; set; }
    public bool IsAvailable { get; set; }
    public string DurationFormatted => GetFormattedDuration();

    public Film(string title, string director, int yearPublished, int durationInMinutes, string genre, bool isAvailable) {
        Title = title;
        Director = director;
        YearPublished = yearPublished;
        DurationInMinutes = durationInMinutes;
        Genre = genre;
        IsAvailable = isAvailable;
    }
    
    private string GetFormattedDuration() {
        TimeSpan duration = TimeSpan.FromMinutes(DurationInMinutes);
        return $"{duration.Hours}h {duration.Minutes}min";
    }
}