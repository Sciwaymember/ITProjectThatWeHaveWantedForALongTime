using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json;
using System.Linq.Expressions;
using Transleader.LibraryServer.BusinessL.Extensions;
using Transleader.LibraryServer.BusinessL.Models;
using Transleader.LibraryServer.DataAccessL;
using Transleader.LibraryServer.DataAccessL.Extensions;
using Transleader.LibraryServer.DataAccessL.Models;
using Transleader.LibraryServer.DataAccessL.Types;

namespace Transleader.LibraryServer.BusinessL.Repositories
{
    ///<summary>
    ///     A IRepository instance which use a SQLServer provider in dbcontext. SQLServerBookRepository designed using Repository pattern.
    /// </summary>
    public class SQLServerBookRepository : IRepository<BookBL>
    {
        private readonly BookDbContext _db;

        private readonly LibgenContext _lg;

        private bool disposedValue;

        public SQLServerBookRepository(IConfiguration configuration)
        {
            _db = new BookDbContext(
                configuration.GetConnectionString("SqlServerBookBase"));
            _lg = new LibgenContext();
        }

        public async Task CreateAsync(BookBL bookBL)
        {
            ///Begins tracking the given entity, and any other reachable entities that are
            ///     not already being tracked, in the <see cref="EntityState.Added" /> state such that they will
            ///     be inserted into the database when <see cref="DbContext.SaveChanges()" /> is called.
            Book book = bookBL.ToDL();
            _db.Books.Add(book);
            _db.BooksCompact.Add(book.ToCompact());
            await SaveAsync();
        }

        public async Task<BookBL?> ReadAsync(Uid id)
        {
            ///Finds an entity with the given primary key values.If an entity with the given primary key values
            ///   is being tracked by the context, then it is returned immediately without making a request to the
            ///   database. Otherwise, a query is made to the database for an entity with the given primary key values
            ///   and this entity, if found, is attached to the context and returned. If no entity is found, then
            ///   null is returned.
            ///   

            BookCompact? bookCompact = await _db.BooksCompact.FindAsync(id);
            BookBL? bookBL = null;

            if (bookCompact != null)
            {
                switch (bookCompact.Source)
                {
                    case Source.Libgen:
                        try
                        {
                            BookLg? bookLg = await _lg.GetBookAsync(id.ToInt());
                            bookBL = bookLg != null ? bookLg.ToBL() : null;
                        }
                        catch (HttpRequestException ex)
                        {
                            throw new HttpRequestException(ex.Message);
                        }
                        catch(JsonSerializationException ex)
                        {
                            throw new JsonSerializationException(ex.Message);
                        }
                        break;

                    case Source.Local:
                        Book? book = await _db.Books.FindAsync(id.ToGuid());
                        bookBL = book != null ? book.ToBL() : null;
                        break;
                }
            }

            return bookBL;
        }

        public async Task UpdateAsync(BookBL bookBL)
        {
            Book book = bookBL.ToDL();

            ///Begins tracking the given entity and entries reachable from the given entity using
            /// <see cref="EntityState.Modified" /> state by default, but see below for cases
            ///when a different state will be used.
            ///Generally, no database interaction will be performed until <see cref="DbContext.SaveChanges()" /> is called.
            ///For entity types with generated keys if an entity has its primary key value set
            ///then it will be tracked in the <see cref="EntityState.Modified" /> state. If the primary key
            ///value is not set then it will be tracked in the <see cref="EntityState.Added" /> state.
            ///This helps ensure new entities will be inserted, while existing entities will be updated.
            ///An entity is considered to have its primary key value set if the primary key property is set
            ///to anything other than the CLR default for the property type.
            _db.Books.Add(book);
            _db.BooksCompact.Add(book.ToCompact());
            await SaveAsync();
        }

        public async Task UpdateAsync(BookBL[] booksBL)
        {
            List<Book> books = new List<Book>();
            List<BookCompact> booksCompact = new List<BookCompact>();

            foreach (var bookBL in booksBL)
            {
                Book book = bookBL.ToDL();
                books.Add(book);
                booksCompact.Add(book.ToCompact());
            }

            _db.Books.UpdateRange(books);
            _db.BooksCompact.UpdateRange(booksCompact);
            await SaveAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Book? book = await _db.Books.FindAsync(id);

            if (book != null)
            {
                ///Begins tracking the given entity in the <see cref="EntityState.Deleted" /> state such that it will
                ///be removed from the database when <see cref="DbContext.SaveChanges()" /> is called.
                _db.Books.Remove(book);
                _db.BooksCompact.Remove(book.ToCompact());
                await SaveAsync();

                return true;
            }

            return false;
        }

        public async Task<int> SaveAsync()
        {
            // Saves all changes made in this context to the database.
            var saveChanges = _db.SaveChangesAsync();
            return await saveChanges;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _db.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~SQLServerBookRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
