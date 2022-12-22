using Microsoft.EntityFrameworkCore;
using Software.Design.Models;

namespace Software.Design.DataModels;

public class CarContext : DbContext
{
    public CarContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Car> Models => Set<Car>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>()
            .HasKey(b => b.ID);

        modelBuilder.Entity<Car>().ToTable("models", schema: "car");
    }
}