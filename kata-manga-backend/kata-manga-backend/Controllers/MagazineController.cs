using kata_manga_backend.Dto;
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
    
    // get all authors
    [HttpGet]
    public async Task<ActionResult<List<MagazineOverviewDto>>> GetAllMagazines()
    {
        var magazines = await GetMagazineDto().ToListAsync();
        return magazines;
    }
    
    // get author by id
    [HttpGet("{id}")]
    public async Task<ActionResult<MagazineOverviewDto>> GetMagazineById(int id)
    {
        var magazine = await GetMagazineDto().FirstOrDefaultAsync(a => a.Id == id);
        if (magazine == null)
        {
            return NotFound();
        }
        return magazine;
    }
    
    // create an author
    [HttpPost]
    public async Task<ActionResult<MagazineOverviewDto>> CreateMagazine([FromBody] MagazineCreationDto body)
    {
        var magazine = new Magazine()
        {
            Name = body.Name,
        };
        _kataMangaContext.Magazine.Add(magazine);
        await _kataMangaContext.SaveChangesAsync();
        
        var createdMagazine = await GetMagazineDto().FirstOrDefaultAsync(e => e.Id == magazine.Id);
        if (createdMagazine == null)
        {
            return Problem("Magazine was not created");
        }
        
        return createdMagazine;
    }
    
    // update an author
    [HttpPut("{id}")]
    public async Task<ActionResult<MagazineOverviewDto>> UpdateMagazine(int id, [FromBody] MagazineCreationDto body)
    {
        var magazine = await _kataMangaContext.Magazine.FirstOrDefaultAsync(a => a.Id == id);
        if (magazine == null)
        {
            return NotFound();
        }

        magazine.Name = body.Name;
        await _kataMangaContext.SaveChangesAsync();

        var updatedMagazine = await GetMagazineDto().FirstOrDefaultAsync(e => e.Id == magazine.Id);
        if (updatedMagazine == null)
        {
            return Problem("Could not get magazine");
        }
        
        return updatedMagazine;
    }
    
    // delete an author
    [HttpDelete("{id}")]
    public async Task<ActionResult<MagazineOverviewDto>> DeleteMagazine(int id)
    {
        var magazine = await _kataMangaContext.Magazine.FirstOrDefaultAsync(a => a.Id == id);
        if (magazine == null)
        {
            return NotFound();
        }
        
        _kataMangaContext.Database.ExecuteSqlRaw("DELETE FROM MangaMagazine WHERE MagazineId = {0}", 
            id);
        await _kataMangaContext.SaveChangesAsync();
        
        _kataMangaContext.Magazine.Remove(magazine);
        await _kataMangaContext.SaveChangesAsync();

        var deletedMagazine = await GetMagazineDto().FirstOrDefaultAsync(e => e.Id == magazine.Id);
        if (deletedMagazine == null)
        {
            return Ok("Magazine was deleted");
        }
        
        return Problem("Magazine was not deleted");
    }

    private IQueryable<MagazineOverviewDto> GetMagazineDto()
    {
        return _kataMangaContext.Magazine.Select(m => new MagazineOverviewDto()
        {
            Id = m.Id,
            Name = m.Name
        });
    }
}