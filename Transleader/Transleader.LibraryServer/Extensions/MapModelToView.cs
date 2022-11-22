using Transleader.LibraryServer.BusinessL.Models;
using Transleader.LibraryServer.Models;

namespace Transleader.LibraryServer.Extensions
{
    public static class MapModelToView
    {
        /// <summary>
        /// Converting BussinessL book to PresentationL book
        /// </summary>
        /// <param name="bookModel"></param>
        /// <returns></returns>
        public static BookView MapToView(this BookModel bookModel)
        {
            BookView book = new BookView()
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
