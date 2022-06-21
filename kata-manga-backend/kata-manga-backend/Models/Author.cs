namespace kata_manga_backend.Models;

public class Author
{
    public int Id { get; set; }
    public string First_name { get; set; }
    public string Last_name { get; set; }
    
    public virtual List<Manga> Mangas { get; set; }
}