using Microsoft.EntityFrameworkCore;
using BookList.Models;
using System.IO.Pipelines;

namespace BookList.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookType> BookTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().ToTable(nameof(Book));
            modelBuilder.Entity<BookType>().ToTable(nameof(BookType));
        }
    }
}
