using System.ComponentModel.DataAnnotations;

namespace kata_manga_backend.Models;

public class MangaGenre
{
    public MangaGenre()
    {
    }
    
    public MangaGenre(int mangaId, int genreId)
    {
        MangaId = mangaId;
        GenreId = genreId;
    }
    
    [Key]
    public int MangaId { get; set; }
    public virtual Manga Manga { get; set; }
    
    public int GenreId { get; set; }
    public virtual Genre Genre { get; set; }
}