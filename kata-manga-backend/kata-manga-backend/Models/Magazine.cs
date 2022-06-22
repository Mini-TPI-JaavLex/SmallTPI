namespace kata_manga_backend.Models;

public class Magazine
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<Manga> Mangas { get; set; }
}