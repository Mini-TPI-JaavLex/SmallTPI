namespace kata_manga_backend.Models;

public class Write
{
    public int Idmanga { get; set; }
    public int Idauthor { get; set; }
    public string Role { get; set; }
    
    public virtual List<Manga> Mangas { get; set; }
    public virtual List<Author> Authors { get; set; }
}