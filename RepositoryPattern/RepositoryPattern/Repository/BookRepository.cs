using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Models;

namespace RepositoryPattern.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _context;
        public BookRepository(BookContext context)
        {
            _context = context;
        }
        public IEnumerable<Book> GetAllBook()
        {
            return _context.Books.ToList();
        }
        public Book GetBookById(int bookId)
        {
            return _context.Books.Find(bookId);
        }
        public int AddBook(Book bookEntity)
        {
            int result = -1;
            if (bookEntity != null)
            {
                _context.Books.Add(bookEntity);
                _context.SaveChanges();
                result = bookEntity.BookId;
            }
            return result;
        }
        public int UpdateBook(Book bookEntity)
        {
            int result = -1;
            if (bookEntity != null)
            {
                _context.Entry(bookEntity).State = EntityState.Modified;
                _context.SaveChanges();
                result = bookEntity.BookId;
            }
            return result;
        }
        public void DeleteBook(int bookId)
        {
            Book BookEntity = _context.Books.Find(bookId);
            _context.Books.Remove(BookEntity);
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}