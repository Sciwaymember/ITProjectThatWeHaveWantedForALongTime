using Transleader.LibraryServer.BusinessL.Models;
using Transleader.LibraryServer.Models;

namespace Transleader.LibraryServer.Extensions
{
    public static class MapViewToModel
    {
        /// <summary>
        /// Converting PresentationL book to BussinessL book
        /// </summary>
        /// <param name="bookView"></param>
        /// <returns></returns>
        public static BookModel MapToModel(this BookView bookView)
        {
            BookModel book = new BookModel
            {
                Id = bookView.Id, // make it nullable if exception
                ParentId = bookView.ParentId,
                Title = bookView.Title,
                Author = bookView.Author,
                CoverPicture = bookView.CoverPicture
            };

            return book;
        }
    }
}
