using System.ComponentModel.DataAnnotations;

namespace kata_manga_backend.Models;

public class Write
{
    public Write()
    {
    }

    public Write(int idmanga, int idauthor)
    {
        Idmanga = idmanga;
        Idauthor = idauthor;
    }
    
    public string Role { get; set; }
    
    [Key]
    public int Idmanga { get; set; }
    public virtual Manga Manga { get; set; }
    
    public int Idauthor { get; set; }
    public virtual Author Author { get; set; }
}