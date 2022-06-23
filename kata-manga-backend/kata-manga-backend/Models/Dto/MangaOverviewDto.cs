using kata_manga_backend.Models;

namespace kata_manga_backend.Dto;

public class MangaOverviewDto
{
    public int Id { get; set; }
    public int? Rank { get; set; }
    public string Title { get; set; }
    public string? Status { get; set; }
    public DateTime? StartDate { get; set; }
    
    public virtual List<AuthorOverviewDto> Authors { get; set; }
    public virtual List<GenreOverviewDto> Genres { get; set; }
    public virtual List<MagazineOverviewDto> Magazines { get; set; }
}