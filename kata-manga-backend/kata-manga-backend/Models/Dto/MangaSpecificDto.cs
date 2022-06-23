namespace kata_manga_backend.Dto;

public class MangaSpecificDto
{
    public int Id { get; set; }
    public int? Rank { get; set; }
    public string Title { get; set; }
    public string? Status { get; set; }
    public DateTime? StartDate { get; set; }
    public string? Synopsis { get; set; }
    public string? ImageUrl { get; set; }
    public int? NumChapters { get; set; }
    public int? NumVolumes { get; set; }
    
    public virtual List<AuthorOverviewDto> Authors { get; set; }
    public virtual List<GenreOverviewDto> Genres { get; set; }
    public virtual List<MagazineOverviewDto> Magazines { get; set; }
}