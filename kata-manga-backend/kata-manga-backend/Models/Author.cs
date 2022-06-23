namespace kata_manga_backend.Models;

public class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public virtual List<MangaAuthor>? MangaAuthors { get; set; }
}