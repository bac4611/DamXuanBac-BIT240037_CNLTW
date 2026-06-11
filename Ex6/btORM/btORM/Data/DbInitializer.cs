using btORM.Models;
using Microsoft.EntityFrameworkCore;

namespace btORM.Data;

public static class DbInitializer
{
    public static async Task InitializeAsync(AppDbContext context)
    {
        await context.Database.EnsureCreatedAsync();

        var seedBooks = new[]
        {
            new Book { Title = "C# C\u01a1 B\u1ea3n", Author = "Nguy\u1ec5n V\u0103n A", Price = 120000, PublishYear = 2022 },
            new Book { Title = "ASP.NET Core MVC", Author = "Tr\u1ea7n V\u0103n B", Price = 180000, PublishYear = 2023 },
            new Book { Title = "Entity Framework Core", Author = "L\u00ea V\u0103n C", Price = 220000, PublishYear = 2024 },
            new Book { Title = "SQL Server Th\u1ef1c Chi\u1ebfn", Author = "Ph\u1ea1m V\u0103n D", Price = 250000, PublishYear = 2021 },
            new Book { Title = "Clean Code", Author = "Robert C. Martin", Price = 350000, PublishYear = 2008 }
        };

        foreach (var seedBook in seedBooks)
        {
            var exists = await context.Books.AnyAsync(book =>
                book.Title == seedBook.Title &&
                book.Author == seedBook.Author);

            if (!exists)
            {
                context.Books.Add(seedBook);
            }
        }

        await context.SaveChangesAsync();
    }
}
