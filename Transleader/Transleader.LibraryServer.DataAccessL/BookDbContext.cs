using Microsoft.EntityFrameworkCore;
using Transleader.LibraryServer.DataAccessL.Models;

namespace Transleader.LibraryServer.DataAccessL
{
    public class BookDbContext : DbContext
    {
        public DbSet<Book> Books => Set<Book>();

        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }
    }
}