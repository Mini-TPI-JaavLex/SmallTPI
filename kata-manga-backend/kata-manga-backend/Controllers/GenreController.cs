using kata_manga_backend.Dto;
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
    
    // get all authors
    [HttpGet]
    public async Task<ActionResult<List<GenreOverviewDto>>> GetAllGenres()
    {
        var genres = await GetGenreDto().ToListAsync();
        return genres;
    }
    
    // get author by id
    [HttpGet("{id}")]
    public async Task<ActionResult<GenreOverviewDto>> GetGenreById(int id)
    {
        var genre = await GetGenreDto().FirstOrDefaultAsync(a => a.Id == id);
        if (genre == null)
        {
            return NotFound();
        }
        return genre;
    }
    
    // create an author
    [HttpPost]
    public async Task<ActionResult<GenreOverviewDto>> CreateGenre([FromBody] GenreCreationDto body)
    {
        var genre = new Genre
        {
            Name = body.Name,
            Description = body.Description,
        };
        _kataMangaContext.Genre.Add(genre);
        await _kataMangaContext.SaveChangesAsync();
        
        var createdGenre = await GetGenreDto().FirstOrDefaultAsync(e => e.Id == genre.Id);
        if (createdGenre == null)
        {
            return Problem("Genre was not created");
        }
        
        return createdGenre;
    }
    
    // update an author
    [HttpPut("{id}")]
    public async Task<ActionResult<GenreOverviewDto>> UpdateGenre(int id, [FromBody] GenreCreationDto body)
    {
        var genre = await _kataMangaContext.Genre.FirstOrDefaultAsync(a => a.Id == id);
        if (genre == null)
        {
            return NotFound();
        }

        genre.Name = body.Name;
        genre.Description = body.Description;
        await _kataMangaContext.SaveChangesAsync();

        var updatedGenre = await GetGenreDto().FirstOrDefaultAsync(e => e.Id == genre.Id);
        if (updatedGenre == null)
        {
            return Problem("Could not get genre");
        }
        
        return updatedGenre;
    }
    
    // delete an author
    [HttpDelete("{id}")]
    public async Task<ActionResult<GenreOverviewDto>> DeleteAuthor(int id)
    {
        var genre = await _kataMangaContext.Genre.FirstOrDefaultAsync(a => a.Id == id);
        if (genre == null)
        {
            return NotFound();
        }
        
        _kataMangaContext.Database.ExecuteSqlRaw("DELETE FROM MangaGenre WHERE GenreId = {0}", 
            id);
        await _kataMangaContext.SaveChangesAsync();
        
        _kataMangaContext.Genre.Remove(genre);
        await _kataMangaContext.SaveChangesAsync();

        var deletedGenre = await GetGenreDto().FirstOrDefaultAsync(e => e.Id == genre.Id);
        if (deletedGenre == null)
        {
            return Ok("Genre was deleted");
        }
        
        return Problem("Genre was not deleted");
    }

    private IQueryable<GenreOverviewDto> GetGenreDto()
    {
        return _kataMangaContext.Genre.Select(m => new GenreOverviewDto()
        {
            Id = m.Id,
            Name = m.Name,
            Description = m.Description
        });
    }
}