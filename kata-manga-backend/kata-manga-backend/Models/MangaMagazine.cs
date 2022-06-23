using System.ComponentModel.DataAnnotations;
using kata_manga_backend.Dto;

namespace kata_manga_backend.Models;

public class MangaMagazine
{
    public MangaMagazine()
    {
    }
    
    public MangaMagazine(int mangaId, int magazineId)
    {
        MangaId = mangaId;
        MagazineId = magazineId;
    }
    
    [Key]
    public int MangaId { get; set; }
    public virtual Manga Manga { get; set; }
    
    public int MagazineId { get; set; }
    public virtual Magazine Magazine { get; set; }
}