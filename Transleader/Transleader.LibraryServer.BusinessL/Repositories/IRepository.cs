using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Transleader.LibraryServer.BusinessL.Repositories
{
    ///<summary>
    ///     A IRepository instance represents a session with the database context and can used for CRUD operations.
    /// </summary>
    public interface IRepository<T>
    {
        ///<summary>
        ///    Sends a requests to db context to add an item to the database
        /// </summary>
        Task Create(T entity);
        ///<summary>
        ///    Sends a requests to db context to get an item from the database by id
        /// </summary>
        Task<T> Read(int id);
        ///<summary>
        ///    Sends a requests to db context to update an element in the database with the passed instance
        /// </summary>
        Task Update(T entity);
        ///<summary>
        ///    Sends a requests to db context to update a range of elements in the database with the passed instance
        /// </summary>
        Task Update(T[] entity);
        ///<summary>
        ///    Sends a requests to db context to delete an element from the database by id
        /// </summary>
        Task<bool> Delete(int id);
        ///<summary>
        ///    Saving changes an sending a request
        /// </summary>
        int Save();
    }
}