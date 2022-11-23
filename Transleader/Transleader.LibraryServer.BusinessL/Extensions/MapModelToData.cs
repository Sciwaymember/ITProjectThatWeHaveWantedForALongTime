using Transleader.LibraryServer.BusinessL.Models;
using Transleader.LibraryServer.DataAccessL.Models;

namespace Transleader.LibraryServer.BusinessL.Extensions
{
    public static class MapModelToData
    {
        /// <summary>
        /// Converting BussinessL book to DataAccessL book
        /// </summary>
        /// <param name="bookModel"></param>
        /// <returns></returns>
        public static Book MapToData(this BookModel bookModel)
        {
            Book book = new Book
            {
                Id = bookModel.Id, // make it nullable if exception
                ParentId = bookModel.ParentId,
                Title = bookModel.Title,
                Author = bookModel.Author,
                CoverPicture = bookModel.CoverPicture
            };

            return book;
        }
    }
}
