using Microsoft.EntityFrameworkCore;
using Transleader.LibraryServer.DataAccessL.Models;
using Transleader.LibraryServer.DataAccessL.Types;

namespace Transleader.LibraryServer.DataAccessL
{
    public class BookDbContext : DbContext
    {
        private string? _connectionString;

        public DbSet<BookCompact> BooksCompact => Set<BookCompact>();

        public DbSet<Book> Books => Set<Book>();

        public BookDbContext(string? connectionString) 
        {
            _connectionString = connectionString;
        }

        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_connectionString != null)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
            else
            {
                base.OnConfiguring(optionsBuilder);
            }
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookCompact>()
                .Property(b => b.Source)
                .HasDefaultValue(Source.Libgen);
            modelBuilder.Entity<BookCompact>()
                .Property(b => b.Id)
                .HasConversion(
                    v => v.ToString(),
                    v => Uid.Parse(v));
        }
    }
}