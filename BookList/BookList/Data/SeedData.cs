using Microsoft.EntityFrameworkCore;
using BookList.Models;

namespace BookList.Data
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices
               .CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Books.Any())
            {
                context.AddRange(
               new Book
               {
                   BookId = 1,
                   Name = "The Sun Also Rises",
                   Year = 1947,
                   Rating = 3,
                   Author = "Ernest Hemingway",
                   BookTypeId = 1
               },
                new Book
                {
                    BookId = 2,
                    Name = "To Kill A Mockingbird",
                    Year = 2001,
                    Rating = 4,
                    Author = "Harper Lee",
                    BookTypeId = 2
                },
                new Book
                {
                    BookId = 3,
                    Name = "Their Eyes Were Watching God",
                    Year = 1997,
                    Rating = 5,
                    Author = "Zora Neale Hurston",
                    BookTypeId = 1
                }
                );
            }

            if (!context.BookTypes.Any())
            {
                context.BookTypes.AddRange(
                new BookType { BookTypeId = 1, BookTypeName = "Fiction" },
                new BookType { BookTypeId = 2, BookTypeName = "NonFiction" }
                
                    );
            }

            context.SaveChanges();
        }
    }
}
