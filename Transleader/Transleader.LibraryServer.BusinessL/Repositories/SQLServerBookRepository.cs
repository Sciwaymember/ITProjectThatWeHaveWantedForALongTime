using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Transleader.LibraryServer.BusinessL.Extensions;
using Transleader.LibraryServer.BusinessL.Models;
using Transleader.LibraryServer.DataAccessL;
using Transleader.LibraryServer.DataAccessL.Models;

namespace Transleader.LibraryServer.BusinessL.Repositories
{
    ///<summary>
    ///     A IRepository instance which used a SQLServer provider in dbcontext. SQLServerBookRepository designed using Repository pattern.
    /// </summary>
    public class SQLServerBookRepository : IRepository<BookModel>
    {
        private BookDbContext _db;

        public SQLServerBookRepository(BookDbContext db)
        {
            _db = db;
        }

        public async Task Create(BookModel book)
        {
            ///Begins tracking the given entity, and any other reachable entities that are
            ///     not already being tracked, in the <see cref="EntityState.Added" /> state such that they will
            ///     be inserted into the database when <see cref="DbContext.SaveChanges()" /> is called.
            _db.Books.Add(book.MapToData());
            Save();
        }

        public async Task<BookModel?> Read(int id)
        {
            ///Finds an entity with the given primary key values.If an entity with the given primary key values
            ///   is being tracked by the context, then it is returned immediately without making a request to the
            ///   database. Otherwise, a query is made to the database for an entity with the given primary key values
            ///   and this entity, if found, is attached to the context and returned. If no entity is found, then
            ///   null is returned.
            Book? bookData = await _db.Books.FindAsync(id);

            BookModel? book = null;

            if (bookData != null)
            {
                book = bookData.MapToModel();
            }

            return book;
        }

        public async Task Update(BookModel book)
        {
            Book bookData = book.MapToData();

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
            _db.Books.Update(bookData);
            Save();
        }

        public async Task Update(BookModel[] bookModels)
        {
            List<Book> books = new List<Book>();

            foreach (var bookModel in bookModels)
            {
                books.Add(bookModel.MapToData());
            }

            _db.Books.UpdateRange(books);
            Save();
        }

        public async Task<bool> Delete(int id)
        {
            Book? book = await _db.Books.FindAsync(id);

            if (book != null)
            {
                ///Begins tracking the given entity in the <see cref="EntityState.Deleted" /> state such that it will
                ///be removed from the database when <see cref="DbContext.SaveChanges()" /> is called.
                _db.Books.Remove(book);
                Save();

                return true;
            }

            return false;
        }

        public int Save()
        {
            // Saves all changes made in this context to the database.
            return _db.SaveChanges();
        }
    }
}
