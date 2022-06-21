using Microsoft.EntityFrameworkCore;

namespace kata_manga_backend.Models;

public class KataMangaContext : DbContext
{
    // connect to mysql database
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost,3306;database=KataManga;user=root;password=root; convert zero datetime=True", ServerVersion.AutoDetect("server=localhost,3306;database=KataManga;user=root;password=root"));
    
    // create a table for manga
    public DbSet<Manga> Manga { get; set; }
    public DbSet<Author> Author { get; set; }
    public DbSet<Genre> Genre { get; set; }
    public DbSet<Magazine> Magazine { get; set; }
    public DbSet<Write> AuthorManga { get; set; }

    // Create modelbuilder
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Manga>(entity =>
        {
            entity.ToTable("manga");
            entity.HasKey(e => e.Id);
        });
        
        // create a table for authors with it's mangas
        modelBuilder.Entity<Author>(entity =>
        {
            entity.ToTable("author");
            entity.HasKey(e => e.Id);
            entity.HasMany(e => e.Mangas).WithMany(e => e.Authors);
        });
        
        // create a table for genres with it's mangas
        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("genre");
            entity.HasKey(e => e.Id);
            entity.HasMany(e => e.Mangas).WithMany(e => e.Genres);
        });
        
        // create a table for magazines with it's mangas
        modelBuilder.Entity<Magazine>(entity =>
        {
            entity.ToTable("magazine");
            entity.HasKey(e => e.Id);
            entity.HasMany(e => e.Mangas).WithMany(e => e.Magazines);
        });
        
        // create an authormanga table with it's author and manga
        modelBuilder.Entity<Write>(entity =>
        {
            entity.ToTable("write");
            entity.HasKey(e => e.Idmanga);
            entity.HasMany(e => e.Mangas);
            entity.HasMany(e => e.Authors);
        });
    }
}