using kata_manga_backend.Dto;
using kata_manga_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

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
    
    [HttpGet("overview")]
    public async Task<ActionResult<List<MangaOverviewDto>>> Get()
    {
        var mangas = await GetMangaDto().OrderBy(e => e.Id).ToListAsync();
        return mangas;
    }
    
    // get manga by id
    [HttpGet("specific/{id}")]
    public async Task<ActionResult<MangaSpecificDto>> Get(int id)
    {
        var manga = await GetSpecificMangaDto().FirstOrDefaultAsync(e => e.Id == id);
        if (manga == null)
        {
            return NotFound();
        }
        return manga;
    }
    
    // Create a new manga
    [HttpPost]
    public async Task<ActionResult<MangaSpecificDto>> Post([FromBody] MangaCreationDto body)
    {

        var manga = new Manga()
        {
            Rank = body.Rank,
            Title = body.Title,
            Status = body.Status,
            StartDate = body.StartDate,
            Synopsis = body.Synopsis,
            ImageUrl = body.ImageUrl,
            NumChapters = body.NumChapters,
            NumVolumes = body.NumVolumes,
        };

            _kataMangaContext.Manga.Add(manga);
        await _kataMangaContext.SaveChangesAsync();

        if (body.MangaAuthors != null)
        {
            foreach (var author in body.MangaAuthors
                         .Select(bodyAuthor => new MangaAuthor() { MangaId = manga.Id, AuthorId = bodyAuthor.AuthorId, Role = bodyAuthor.Role }))
            {
                _kataMangaContext.MangaAuthor.Add(author);
            }
        }
        
        if (body.MangaGenres != null)
        {
            foreach (var genre in body.MangaGenres
                         .Select(bodyGenre => new MangaGenre() { MangaId = manga.Id, GenreId = bodyGenre.GenreId }))
            {
                _kataMangaContext.MangaGenre.Add(genre);
            }
        }
        
        if (body.MangaMagazines != null)
        {
            foreach (var magazine in body.MangaMagazines
                         .Select(bodyMagazine => new MangaMagazine() { MangaId = manga.Id, MagazineId = bodyMagazine.MagazineId }))
            {
                _kataMangaContext.MangaMagazine.Add(magazine);
            }
        }
        
        await _kataMangaContext.SaveChangesAsync();
        
        var createdManga = await GetSpecificMangaDto().FirstOrDefaultAsync(e => e.Id == manga.Id);
        if (createdManga == null)
        {
            return Problem("Manga was not created");
        }
        
        return createdManga;;
    }
    
    // Update a manga
    [HttpPut("{id}")]
    public async Task<ActionResult<MangaSpecificDto>> Put(int id, [FromBody] MangaCreationDto body)
    {
        var manga = await _kataMangaContext.Manga.FirstOrDefaultAsync(e => e.Id == id);
        
        manga.Rank = body.Rank;
        manga.Title = body.Title;
        manga.Status = body.Status;
        manga.StartDate = body.StartDate;
        manga.Synopsis = body.Synopsis;
        manga.ImageUrl = body.ImageUrl;
        manga.NumChapters = body.NumChapters;
        manga.NumVolumes = body.NumVolumes;
        
        await _kataMangaContext.SaveChangesAsync();
        
        _kataMangaContext.Database.ExecuteSqlRaw("DELETE FROM MangaAuthor WHERE MangaId = {0}", 
            id);
        _kataMangaContext.Database.ExecuteSqlRaw("DELETE FROM MangaGenre WHERE MangaId = {0}", 
            id);
        _kataMangaContext.Database.ExecuteSqlRaw("DELETE FROM MangaMagazine WHERE MangaId = {0}", 
            id);
        await _kataMangaContext.SaveChangesAsync();
        
        if (body.MangaAuthors != null)
        {
            foreach (var author in body.MangaAuthors
                         .Select(bodyAuthor => new MangaAuthor() { MangaId = manga.Id, AuthorId = bodyAuthor.AuthorId, Role = bodyAuthor.Role }))
            {
                _kataMangaContext.MangaAuthor.Add(author);
            }
        }
        
        if (body.MangaGenres != null)
        {
            foreach (var genre in body.MangaGenres
                         .Select(bodyGenre => new MangaGenre() { MangaId = manga.Id, GenreId = bodyGenre.GenreId }))
            {
                _kataMangaContext.MangaGenre.Add(genre);
            }
        }
        
        if (body.MangaMagazines != null)
        {
            foreach (var magazine in body.MangaMagazines
                         .Select(bodyMagazine => new MangaMagazine() { MangaId = manga.Id, MagazineId = bodyMagazine.MagazineId }))
            {
                _kataMangaContext.MangaMagazine.Add(magazine);
            }
        }
        
        await _kataMangaContext.SaveChangesAsync();
        
        var updatedManga = await GetSpecificMangaDto().FirstOrDefaultAsync(e => e.Id == manga.Id);
        if (updatedManga == null)
        {
            return Problem("Could not get manga");
        }
        
        return updatedManga;;
    }

    // Delete a manga
    [HttpDelete("{id}")]
    public async Task<ActionResult<MangaSpecificDto>> Delete(int id)
    {
        var manga = await _kataMangaContext.Manga.FirstOrDefaultAsync(e => e.Id == id);
        if (manga == null)
        {
            return NotFound();
        }
        
        _kataMangaContext.Database.ExecuteSqlRaw("DELETE FROM MangaAuthor WHERE MangaId = {0}", 
            id);
        _kataMangaContext.Database.ExecuteSqlRaw("DELETE FROM MangaGenre WHERE MangaId = {0}", 
            id);
        _kataMangaContext.Database.ExecuteSqlRaw("DELETE FROM MangaMagazine WHERE MangaId = {0}", 
            id);
        await _kataMangaContext.SaveChangesAsync();
        
        _kataMangaContext.Manga.Remove(manga);
        await _kataMangaContext.SaveChangesAsync();

        var deletedManga = await GetSpecificMangaDto().FirstOrDefaultAsync(e => e.Id == manga.Id);
        if (deletedManga == null)
        {
            return Ok("Manga was deleted");
        }
        
        return Problem("Manga was not deleted");
    }

    private IQueryable<MangaOverviewDto> GetMangaDto()
    {
        return _kataMangaContext.Manga.Select(m => new MangaOverviewDto()
        {
            Id = m.Id,
            Rank = m.Rank,
            Title = m.Title,
            Status = m.Status,
            StartDate = m.StartDate,
            Authors = m.MangaAuthors.Select(e => e.Author).Select(a => new AuthorOverviewDto()
            {
                Id = a.Id, 
                FirstName = a.FirstName, 
                LastName = a.LastName
            }).ToList(),
            Genres = m.MangaGenres.Select(e => e.Genre).Select(g => new GenreOverviewDto()
            {
                Id = g.Id,
                Name = g.Name,
                Description = g.Description
            }).ToList(),
            Magazines = m.MangaMagazines.Select(e => e.Magazine).Select(g => new MagazineOverviewDto()
            {
                Id = g.Id,
                Name = g.Name
            }).ToList()
        });
    }
    
    private IQueryable<MangaSpecificDto> GetSpecificMangaDto()
    {
        return _kataMangaContext.Manga.Select(m => new MangaSpecificDto()
        {
            Id = m.Id,
            Rank = m.Rank,
            Title = m.Title,
            Status = m.Status,
            StartDate = m.StartDate,
            Synopsis = m.Synopsis,
            ImageUrl = m.ImageUrl,
            NumChapters = m.NumChapters,
            NumVolumes = m.NumVolumes,
            Authors = m.MangaAuthors.Select(e => e.Author).Select(a => new AuthorOverviewDto()
            {
                Id = a.Id, 
                FirstName = a.FirstName, 
                LastName = a.LastName
            }).ToList(),
            Genres = m.MangaGenres.Select(e => e.Genre).Select(g => new GenreOverviewDto()
            {
                Id = g.Id,
                Name = g.Name,
                Description = g.Description
            }).ToList(),
            Magazines = m.MangaMagazines.Select(e => e.Magazine).Select(g => new MagazineOverviewDto()
            {
                Id = g.Id,
                Name = g.Name
            }).ToList()
        });
    }
}