using System.ComponentModel.DataAnnotations;

namespace kata_manga_backend.Models;

public class Classify
{
    [Key]
    public int Idmanga { get; set; }
    public virtual Manga Manga { get; set; }
    
    public int Idgenre { get; set; }
    public virtual Genre Genre { get; set; }
}