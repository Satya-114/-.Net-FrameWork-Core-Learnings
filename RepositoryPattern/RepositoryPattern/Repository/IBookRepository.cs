using RepositoryPattern.Models;

namespace RepositoryPattern.Repository
{
    public interface IBookRepository : IDisposable
    {
        IEnumerable<Book> GetAllBook();
        Book GetBookById(int id);
        int AddBook(Book bookEntity);
        int UpdateBook(Book bookEntity);
        void DeleteBook(int bookId);

    }
}
