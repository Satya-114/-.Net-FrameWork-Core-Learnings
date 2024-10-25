using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace RepositoryPattern.Models
{
    public class BookContext : DbContext
    {
        public BookContext()
        {
        }
        public BookContext(DbContextOptions<BookContext>options) : base(options) { }
        public DbSet<Book> Books
        {
            get;
            set;
        }
    }
}
