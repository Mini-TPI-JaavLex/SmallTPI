using System.ComponentModel.DataAnnotations;

namespace kata_manga_backend.Models;

public class MangaAuthor
{
    public MangaAuthor()
    {
    }

    public MangaAuthor(int mangaId, int authorId)
    {
        MangaId = mangaId;
        AuthorId = authorId;
    }
    
    public string Role { get; set; }
    
    [Key]
    public int MangaId { get; set; }
    public virtual Manga Manga { get; set; }
    
    public int AuthorId { get; set; }
    public virtual Author Author { get; set; }
}