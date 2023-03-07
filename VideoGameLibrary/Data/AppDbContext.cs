using Microsoft.EntityFrameworkCore;
using VideoGameLibrary.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }
    public DbSet<Games> GamesDB { get; set; }

}

