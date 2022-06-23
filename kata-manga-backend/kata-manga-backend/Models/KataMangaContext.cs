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
    public DbSet<MangaAuthor> MangaAuthor { get; set; }
    public DbSet<MangaGenre> MangaGenre { get; set; }
    public DbSet<MangaMagazine> MangaMagazine { get; set; }

    // Create modelbuilder
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Manga>(entity =>
        {
            entity.ToTable("Manga");
            entity.HasKey(e => e.Id);
        });
        
        // create a table for authors with it's mangas
        modelBuilder.Entity<Author>(entity =>
        {
            entity.ToTable("Author");
            entity.HasKey(e => e.Id);
        });
        
        // create a table for genres with it's mangas
        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("Genre");
            entity.HasKey(e => e.Id);
        });
        
        // create a table for magazines with it's mangas
        modelBuilder.Entity<Magazine>(entity =>
        {
            entity.ToTable("Magazine");
            entity.HasKey(e => e.Id);
        });
        
        // create an MangaAuthor table with it's author and manga
        modelBuilder.Entity<MangaAuthor>(entity =>
        {
            entity.ToTable("MangaAuthor");
            entity.HasOne(e => e.Manga)
                .WithMany(e => e.MangaAuthors)
                .HasForeignKey(e => e.MangaId);
            entity.HasOne(e => e.Author)
                .WithMany(e => e.MangaAuthors)
                .HasForeignKey(e => e.AuthorId);
        });
        
        // create an MangaMagazine table with it's author and manga
        modelBuilder.Entity<MangaMagazine>(entity =>
        {
            entity.ToTable("MangaMagazine");
            entity.HasOne(e => e.Manga)
                .WithMany(e => e.MangaMagazines)
                .HasForeignKey(e => e.MangaId);
            entity.HasOne(e => e.Magazine)
                .WithMany(e => e.MangaMagazines)
                .HasForeignKey(e => e.MagazineId);
        });
        
        // create an MangaGenre table with it's author and manga
        modelBuilder.Entity<MangaGenre>(entity =>
        {
            entity.ToTable("MangaGenre");
            entity.HasOne(e => e.Manga)
                .WithMany(e => e.MangaGenres)
                .HasForeignKey(e => e.MangaId);
            entity.HasOne(e => e.Genre)
                .WithMany(e => e.MangaGenres)
                .HasForeignKey(e => e.GenreId);
        });
    }
}