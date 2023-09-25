using BookList.Models;

namespace BookList.Data
{
    public interface IBookRepository
    {
        public IEnumerable<Book> GetAllBooks();
        public IEnumerable<Book> GetAllBooksWithBookTypeDetails();
        public IEnumerable<BookType> GetAllBookTypes();
        public Book GetBookById(int id);

        public void SaveChanges();
        public void AddBook(Book book);

        public void DeleteBook(Book book);

        public void UpdateBook(Book book);
    }
}
