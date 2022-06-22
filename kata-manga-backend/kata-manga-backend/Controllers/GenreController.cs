using kata_manga_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kata_manga_backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenreController : ControllerBase
{
    private readonly KataMangaContext _kataMangaContext;
    
    public GenreController()
    {
        _kataMangaContext = new KataMangaContext();
    }
    
    // get a list of all genres
    [HttpGet("all")]
    public async Task<List<Genre>> GetAllGenres()
    {
        var genres = await _kataMangaContext.Genre.ToListAsync();
        return genres;
    }
    
    // get a list of all genres by id
    [HttpGet("{id}")]
    public async Task<Genre> GetGenreById(int id)
    {
        var genre = await _kataMangaContext.Genre.FindAsync(id);
        return genre;
    }
    
    // create a new genre
    [HttpPost("create")]
    public async Task<IActionResult> CreateGenre([FromBody] Genre genre)
    {
        _kataMangaContext.Genre.Add(genre);
        await _kataMangaContext.SaveChangesAsync();
        return Ok(genre);
    }
    
    // update a genre
    [HttpPut("update")]
    public async Task<IActionResult> UpdateGenre([FromBody] Genre genre)
    {
        _kataMangaContext.Genre.Update(genre);
        await _kataMangaContext.SaveChangesAsync();
        return Ok(genre);
    }
    
    // delete a genre
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteGenre(int id)
    {
        var genre = await _kataMangaContext.Genre.FindAsync(id);
        _kataMangaContext.Genre.Remove(genre);
        await _kataMangaContext.SaveChangesAsync();
        return Ok(genre);
    }
    
    // get a list of all genres with it's mangas
    [HttpGet("all/mangas")]
    public async Task<List<Genre>> GetAllGenresWithMangas()
    {
        var genres = await _kataMangaContext.Genre.Include(g => g.Mangas).ToListAsync();
        return genres;
    }
    
    // get a list of all genres with it's mangas by id
    [HttpGet("{id}/mangas")]
    public async Task<Genre> GetGenreByIdWithMangas(int id)
    {
        var genre = await _kataMangaContext.Genre.Include(g => g.Mangas).FirstOrDefaultAsync(a => a.Id == id);
        return genre;
    }

}