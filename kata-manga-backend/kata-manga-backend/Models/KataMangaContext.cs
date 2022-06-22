using Microsoft.EntityFrameworkCore;

namespace kata_manga_backend.Models;

public class KataMangaContext : DbContext
{
    // connect to mysql database
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost,3306;database=KataManga;user=root;password=root; Convert Zero Datetime=true", ServerVersion.AutoDetect("server=localhost,3306;database=KataManga;user=root;password=root"));
    
    // create a table for manga
    public DbSet<Manga> Manga { get; set; }
    public DbSet<Author> Author { get; set; }
    public DbSet<Genre> Genre { get; set; }
    public DbSet<Magazine> Magazine { get; set; }
    public DbSet<Write> Write { get; set; }

    // Create modelbuilder
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Manga>(entity =>
        {
            entity.ToTable("manga");
            entity.HasKey(e => e.Id);
            entity.HasMany(e => e.Write);
            entity.HasMany(e => e.Classify);
            entity.HasMany(e => e.Publish);
        });
        
        // create a table for authors with it's mangas
        modelBuilder.Entity<Author>(entity =>
        {
            entity.ToTable("author");
            entity.HasKey(e => e.Id);
            entity.HasMany(e => e.Mangas);
        });
        
        // create a table for genres with it's mangas
        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("genre");
            entity.HasKey(e => e.Id);
            entity.HasMany(e => e.Mangas);
        });
        
        // create a table for magazines with it's mangas
        modelBuilder.Entity<Magazine>(entity =>
        {
            entity.ToTable("magazine");
            entity.HasKey(e => e.Id);
            entity.HasMany(e => e.Mangas);
        });
        
        // create an authormanga table with it's author and manga
        modelBuilder.Entity<Write>(entity =>
        {
            entity.ToTable("write");
            entity.HasKey(e => e.Idmanga);
            entity.HasOne(e => e.Author);
            entity.HasOne(e => e.Manga);
        });
    }
}