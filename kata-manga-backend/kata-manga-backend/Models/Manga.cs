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
        Start_date = startDate;
        End_date = endDate;
        Synopsis = synopsis;
        Image_url = imageUrl;
        Num_chapters = numChapters;
        Num_volumes = numVolumes;
    }
    public int Id { get; set; }
    public int? Rank { get; set; }
    public string Title { get; set; }
    public string? Status { get; set; }
    public DateTime? Start_date { get; set; }
    public DateTime? End_date { get; set; }
    public string? Synopsis { get; set; }
    public string? Image_url { get; set; }
    public int? Num_chapters { get; set; }
    public int? Num_volumes { get; set; }
    
    public virtual List<Write>? Write { get; set; }
    public virtual List<Classify>? Classify { get; set; }
    public virtual List<Publish>? Publish { get; set; }
}