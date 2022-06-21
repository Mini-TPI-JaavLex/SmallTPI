using kata_manga_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kata_manga_backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MangaController : ControllerBase
{
    private readonly KataMangaContext _kataMangaContext;
    
    public MangaController()
    {
        _kataMangaContext = new KataMangaContext();
    }
    
    [HttpGet("all")]
    public async Task<List<Manga>> Get()
    {
        var mangas = await _kataMangaContext.Manga.ToListAsync();
        return mangas;
    }
    
    // get manga by ID
    [HttpGet("{id}")]
    public async Task<Manga> Get(int id)
    {
        var manga = await _kataMangaContext.Manga.FindAsync(id);
        return manga;
    }
    
    // create manga
    [HttpPost]
    public async Task<ActionResult<Manga>> Post([FromBody] Manga manga)
    {
        _kataMangaContext.Manga.Add(manga);
        await _kataMangaContext.SaveChangesAsync();
        return manga;
    }
    
    // update manga
    [HttpPut("{id}")]
    public async Task<ActionResult<Manga>> Put(int id, [FromBody] Manga manga)
    {
        _kataMangaContext.Entry(manga).State = EntityState.Modified;
        await _kataMangaContext.SaveChangesAsync();
        return manga;
    }

    // delete manga
    [HttpDelete("{id}")]
    public async Task<ActionResult<Manga>> Delete(int id)
    {
        var manga = await _kataMangaContext.Manga.FindAsync(id);
        if (manga == null)
        {
            return NotFound();
        }
        _kataMangaContext.Manga.Remove(manga);
        await _kataMangaContext.SaveChangesAsync();
        return manga;
    }
}