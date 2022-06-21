namespace kata_manga_backend.Models;

public class Classify
{
    public int Idmanga { get; set; }
    public int Idgenre { get; set; }

    public virtual List<Manga> Mangas { get; set; }
    public virtual List<Genre> Genres { get; set; }
}