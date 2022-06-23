using kata_manga_backend.Models;

namespace kata_manga_backend.Dto;

public class MangaCreationDto
{
    public int? Rank { get; set; }
    public string Title { get; set; }
    public string? Status { get; set; }
    public DateTime? StartDate { get; set; }
    public string? Synopsis { get; set; }
    public string? ImageUrl { get; set; }
    public int? NumChapters { get; set; }
    public int? NumVolumes { get; set; }
    public virtual List<MangaAuthorCreationDto>? MangaAuthors { get; set; }
    public virtual List<MangaGenreCreationDto>? MangaGenres { get; set; }
    public virtual List<MangaMagazineCreationDto>? MangaMagazines { get; set; }
}