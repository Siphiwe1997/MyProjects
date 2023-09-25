using BookList.Models;
using Microsoft.EntityFrameworkCore;

namespace BookList.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _appDbContext;

        public BookRepository(AppDbContext appContext)
        {
            _appDbContext = appContext;
        }

        public IEnumerable<Book> AllBooks()
        {
            return _appDbContext.Books;
        }

        public void AddBook(Book book)
        {
            _appDbContext.Books.Add(book);
        }

        public void DeleteBook(int id)
        {
            _appDbContext.Remove<Book>(GetBookById(id));
        }
        public void DeleteBook(Book book)
        {
            _appDbContext.Remove(book);
        }

        public IEnumerable<BookType> GetAllBookTypes()
        {
            return _appDbContext.BookTypes;
        }

        public Book GetBookById(int id)
        {
            return _appDbContext.Books.FirstOrDefault(m => m.BookId == id);
        }

        public void SaveChanges()
        {
            _appDbContext.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            _appDbContext.Update(book);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAllBooksWithBookTypeDetails()
        {
            return _appDbContext.Books.Include(m => m.BookType);
        }
    }
}
