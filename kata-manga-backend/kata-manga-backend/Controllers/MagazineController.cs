using kata_manga_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kata_manga_backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MagazineController : ControllerBase
{
    private readonly KataMangaContext _kataMangaContext;
    
    public MagazineController()
    {
        _kataMangaContext = new KataMangaContext();
    }
    
    // get a list of all magazines
    [HttpGet("all")]
    public async Task<List<Magazine>> GetAllMagazines()
    {
        var magazines = await _kataMangaContext.Magazine.ToListAsync();
        return magazines;
    }
    
    // get a list of all magazines by their id
    [HttpGet("{id}")]
    public async Task<Magazine> GetMagazineById(int id)
    {
        var magazine = await _kataMangaContext.Magazine.FindAsync(id);
        return magazine;
    }
    
    // create a new magazine
    [HttpPost("create")]
    public async Task<ActionResult<Magazine>> CreateMagazine(Magazine magazine)
    {
        _kataMangaContext.Magazine.Add(magazine);
        await _kataMangaContext.SaveChangesAsync();
        return magazine;
    }
    
    // update a magazine
    [HttpPut("update")]
    public async Task<ActionResult<Magazine>> UpdateMagazine(Magazine magazine)
    {
        _kataMangaContext.Magazine.Update(magazine);
        await _kataMangaContext.SaveChangesAsync();
        return magazine;
    }
    
    // delete a magazine
    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<Magazine>> DeleteMagazine(int id)
    {
        var magazine = await _kataMangaContext.Magazine.FirstOrDefaultAsync(a => a.Id == id);
        if (magazine == null)
        {
            return NotFound();
        }
        _kataMangaContext.Magazine.Remove(magazine);
        await _kataMangaContext.SaveChangesAsync();
        return magazine;
    }
    
    // get a list of magazines with their mangas
    [HttpGet("mangas")]
    public async Task<List<Magazine>> GetMagazinesWithMangas()
    {
        var magazines = await _kataMangaContext.Magazine.Include(a => a.Mangas).ToListAsync();
        return magazines;
    }
    
    // get a list of magazines with their mangas by their id
    [HttpGet("mangas/{id}")]
    public async Task<Magazine> GetMagazinesWithMangasById(int id)
    {
        var magazine = await _kataMangaContext.Magazine.Include(a => a.Mangas).FirstOrDefaultAsync(a => a.Id == id);
        return magazine;
    }
}