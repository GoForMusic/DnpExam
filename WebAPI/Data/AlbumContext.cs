using Entities;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Data;

public class AlbumContext : DbContext
{
    public DbSet<Album> Albums { get; set; } = null!;
    public DbSet<Image> Images { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source = ..\WebAPI\Data\Album.db");
        optionsBuilder.EnableSensitiveDataLogging();
    }
}