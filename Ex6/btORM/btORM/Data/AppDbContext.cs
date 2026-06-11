using btORM.Models;
using Microsoft.EntityFrameworkCore;

namespace btORM.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .Property(book => book.Price)
            .HasPrecision(18, 2);
    }
}
