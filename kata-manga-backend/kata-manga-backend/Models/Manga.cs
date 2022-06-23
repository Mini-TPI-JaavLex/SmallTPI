using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Runtime.Serialization;
using Microsoft.VisualBasic;

namespace kata_manga_backend.Models;

public class Manga
{

    public Manga()
    {
    }
    public Manga(int? rank, string title, string? status, DateTime? startDate, DateTime? endDate, string? synopsis, string? imageUrl, int? numChapters, int? numVolumes)
    {
        Rank = rank;
        Title = title;
        Status = status;
        StartDate = startDate;
        EndDate = endDate;
        Synopsis = synopsis;
        ImageUrl = imageUrl;
        NumChapters = numChapters;
        NumVolumes = numVolumes;
    }
    public int Id { get; set; }
    public int? Rank { get; set; }
    public string Title { get; set; }
    public string? Status { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Synopsis { get; set; }
    public string? ImageUrl { get; set; }
    public int? NumChapters { get; set; }
    public int? NumVolumes { get; set; }
    
    public virtual List<MangaAuthor>? MangaAuthors { get; set; }
    public virtual List<MangaGenre>? MangaGenres { get; set; }
    public virtual List<MangaMagazine>? MangaMagazines { get; set; }
}