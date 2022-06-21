using kata_manga_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kata_manga_backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly KataMangaContext _kataMangaContext;
    
    public AuthorController()
    {
        _kataMangaContext = new KataMangaContext();
    }

    // get a list of all authors
    [HttpGet("all")]
    public async Task<List<Author>> GetAllAuthors()
    {
        var authors = await _kataMangaContext.Author.ToListAsync();
        return authors;
    }
    
    // get author by id
    [HttpGet("{id}")]
    public async Task<Author> GetAuthorById(int id)
    {
        var author = await _kataMangaContext.Author.FirstOrDefaultAsync(a => a.Id == id);
        return author;
    }
    
    // create a new author
    [HttpPost]
    public async Task<ActionResult<Author>> CreateAuthor(Author author)
    {
        _kataMangaContext.Author.Add(author);
        await _kataMangaContext.SaveChangesAsync();
        return author;
    }
    
    // update an author
    [HttpPut("{id}")]
    public async Task<ActionResult<Author>> UpdateAuthor(int id, Author author)
    {
        if (id != author.Id)
        {
            return BadRequest();
        }
        _kataMangaContext.Entry(author).State = EntityState.Modified;
        await _kataMangaContext.SaveChangesAsync();
        return author;
    }
    
    // delete an author
    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<Author>> DeleteAuthor(int id)
    {
        var author = await _kataMangaContext.Author.FirstOrDefaultAsync(a => a.Id == id);
        if (author == null)
        {
            return NotFound();
        }
        _kataMangaContext.Author.Remove(author);
        await _kataMangaContext.SaveChangesAsync();
        return author;
    }
    
    // get a list of all authors with their respective manga
    [HttpGet("all/manga")]
    public async Task<List<Author>> GetAllAuthorsWithManga()
    {
        var authors = await _kataMangaContext.Author.Include(a => a.Mangas).ToListAsync();
        return authors;
    }
    
    // get an author with their respective manga
    [HttpGet("{id}/manga")]
    public async Task<Author> GetAuthorWithMangaById(int id)
    {
        var author = await _kataMangaContext.Author.Include(a => a.Mangas).FirstOrDefaultAsync(a => a.Id == id);
        return author;
    }
}