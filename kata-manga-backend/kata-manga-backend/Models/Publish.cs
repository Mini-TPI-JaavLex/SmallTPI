using System.ComponentModel.DataAnnotations;

namespace kata_manga_backend.Models;

public class Publish
{
    
    [Key]
    public int Idmanga { get; set; }
    public virtual Manga Manga { get; set; }
    
    public int Idmagazine { get; set; }
    public virtual Magazine Magazine { get; set; }
}