using kata_manga_backend.Dto;
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
    public async Task<List<MangaDto>> Get()
    {
        var mangas = await GetMangaDto().OrderBy(e => e.Id).ToListAsync();
        return mangas;
    }
    
    // get manga by ID
    [HttpGet("{id}")]
    public async Task<MangaDto> Get(int id)
    {
        var manga = await GetMangaDto().Where(e => e.Id == id).FirstOrDefaultAsync();
        return manga;
    }
    
    // create manga
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Manga body)
    {
        var manga = new Manga(body.Rank, body.Title, body.Status, body.Start_date, body.End_date, body.Synopsis,
            body.Image_url, body.Num_chapters, body.Num_volumes);
        _kataMangaContext.Manga.Add(manga);
        await _kataMangaContext.SaveChangesAsync();
        return Ok();
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

    private IQueryable<MangaDto> GetMangaDto()
    {
        return _kataMangaContext.Manga.Select(m => new MangaDto()
        {
            Id = m.Id,
            Title = m.Title,
            Status = m.Status,
            Start_date = m.Start_date,
            End_date = m.End_date,
            Synopsis = m.Synopsis,
            Image_url = m.Image_url,
            Num_chapters = m.Num_chapters,
            Num_volumes = m.Num_volumes,
        });
    }
}