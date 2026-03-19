using LevelUpBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace LevelUpBackend.Data;
public class LevelUpRentalsDbContext : DbContext
{
    public LevelUpRentalsDbContext(DbContextOptions<LevelUpRentalsDbContext> options) : base(options) { }
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Rental> Rentals => Set<Rental>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Senior Signal: Explicitly define decimal precision for money
        modelBuilder.Entity<Game>()
            .Property(g => g.HourlyRate)
            .HasPrecision(18, 2);
    }
}