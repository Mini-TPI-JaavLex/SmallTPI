namespace kata_manga_backend.Models;

public class Publish
{
    public int Idmanga { get; set; }
    public int Idmagazine { get; set; }
    
    public virtual List<Manga> Mangas { get; set; }
    public virtual List<Magazine> Magazines { get; set; }
}