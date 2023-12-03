namespace LibraryApp.Models;

public class Film {

    public string Title { get; }
    public string Director { get; }
    public int YearPublished { get; }
    public int DurationInMinutes { get; }
    public string Genre { get; }
    public string RecommendedAge { get; }
    public string DurationFormatted => GetFormattedDuration();

    public Film(string title, string director, int yearPublished, int durationInMinutes, string genre, string recommendedAge) {
        Title = title;
        Director = director;
        YearPublished = yearPublished;
        DurationInMinutes = durationInMinutes;
        Genre = genre;
        RecommendedAge = recommendedAge;
    }
    
    private string GetFormattedDuration() {
        TimeSpan duration = TimeSpan.FromMinutes(DurationInMinutes);
        return $"{duration.Hours}h {duration.Minutes}min";
    }
}