using kata_manga_backend.Dto;
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

    // get all authors
    [HttpGet]
    public async Task<ActionResult<List<AuthorOverviewDto>>> GetAllAuthors()
    {
        var authors = await GetAuthorDto().ToListAsync();
        return authors;
    }
    
    // get author by id
    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorOverviewDto>> GetAuthorById(int id)
    {
        var author = await GetAuthorDto().FirstOrDefaultAsync(a => a.Id == id);
        if (author == null)
        {
            return NotFound();
        }
        return author;
    }
    
    // create an author
    [HttpPost]
    public async Task<ActionResult<AuthorOverviewDto>> CreateAuthor([FromBody] AuthorCreationDto body)
    {
        var author = new Author
        {
            FirstName = body.FirstName,
            LastName = body.LastName,
        };
        _kataMangaContext.Author.Add(author);
        await _kataMangaContext.SaveChangesAsync();
        
        var createdAuthor = await GetAuthorDto().FirstOrDefaultAsync(e => e.Id == author.Id);
        if (createdAuthor == null)
        {
            return Problem("Author was not created");
        }
        
        return createdAuthor;
    }
    
    // update an author
    [HttpPut("{id}")]
    public async Task<ActionResult<AuthorOverviewDto>> UpdateAuthor(int id, [FromBody] AuthorCreationDto body)
    {
        var author = await _kataMangaContext.Author.FirstOrDefaultAsync(a => a.Id == id);
        if (author == null)
        {
            return NotFound();
        }

        author.FirstName = body.FirstName;
        author.LastName = body.LastName;
        await _kataMangaContext.SaveChangesAsync();

        var updatedAuthor = await GetAuthorDto().FirstOrDefaultAsync(e => e.Id == author.Id);
        if (updatedAuthor == null)
        {
            return Problem("Could not get author");
        }
        
        return updatedAuthor;
    }
    
    // delete an author
    [HttpDelete("{id}")]
    public async Task<ActionResult<AuthorOverviewDto>> DeleteAuthor(int id)
    {
        var author = await _kataMangaContext.Author.FirstOrDefaultAsync(a => a.Id == id);
        if (author == null)
        {
            return NotFound();
        }
        
        _kataMangaContext.Database.ExecuteSqlRaw("DELETE FROM MangaAuthor WHERE AuthorId = {0}", 
            id);
        await _kataMangaContext.SaveChangesAsync();
        
        _kataMangaContext.Author.Remove(author);
        await _kataMangaContext.SaveChangesAsync();

        var deletedAuthor = await GetAuthorDto().FirstOrDefaultAsync(e => e.Id == author.Id);
        if (deletedAuthor == null)
        {
            return Ok("Author was deleted");
        }
        
        return Problem("Author was not deleted");
    }

    private IQueryable<AuthorOverviewDto> GetAuthorDto()
    {
        return _kataMangaContext.Author.Select(m => new AuthorOverviewDto()
        {
            Id = m.Id,
            FirstName = m.FirstName,
            LastName = m.LastName
        });
    }
}