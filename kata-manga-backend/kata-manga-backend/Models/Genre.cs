using Microsoft.AspNetCore.Mvc;

namespace kata_manga_backend.Models;

public class Genre
{
    public Genre()
    {
    }
    
    public Genre(string name, string description)
    {
        Name = name;
        Description = description;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public virtual List<MangaGenre>? MangaGenres { get; set; }
}