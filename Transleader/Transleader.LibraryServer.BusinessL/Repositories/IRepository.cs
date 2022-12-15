using Microsoft.EntityFrameworkCore.Diagnostics;
using Transleader.LibraryServer.BusinessL.Models;
using Transleader.LibraryServer.DataAccessL.Types;

namespace Transleader.LibraryServer.BusinessL.Repositories
{
    ///<summary>
    ///     A IRepository instance represents a session with the database context and can used for CRUD operations.
    /// </summary>
    public interface IRepository<T> : IDisposable
    {
        ///<summary>
        ///    Sends a requests to db context to add an item to the database
        /// </summary>
        Task CreateAsync(T entity);
        ///<summary>
        ///    Sends a requests to db or lg context to get an item from the database by id
        /// </summary>
        Task<T?> ReadAsync(Uid id);
        ///<summary>
        ///    Sends a requests to db context to update an element in the database with the passed instance
        /// </summary>
        Task UpdateAsync(T entity);
        ///<summary>
        ///    Sends a requests to db context to update a range of elements in the database with the passed instance
        /// </summary>
        Task UpdateAsync(T[] entity);
        ///<summary>
        ///    Sends a requests to db context to delete an element from the database by id
        /// </summary>
        Task<bool> DeleteAsync(int id);

        ///<summary>
        ///    Saving changes an sending a request
        /// </summary>
        Task<int> SaveAsync();
    }
}