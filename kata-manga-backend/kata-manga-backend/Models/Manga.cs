using System.Globalization;
using System.Runtime.Serialization;
using Microsoft.VisualBasic;

namespace kata_manga_backend.Models;

public class Manga
{
    public int Id { get; set; }
    public int? Rank { get; set; }
    public string Title { get; set; }
    public string? status { get; set; }
    public DateTime? Start_date { get; set; }
    public DateTime? End_date { get; set; }
    public string? Synopsis { get; set; }
    public string? Image_url { get; set; }
    public int? Num_chapters { get; set; }
    public int? Num_volumes { get; set; }
}