using Transleader.LibraryServer.BusinessL.Models;
using Transleader.LibraryServer.DataAccessL.Models;

namespace Transleader.LibraryServer.BusinessL.Extensions
{
    public static class BookBusinessToDataMapper
    {
        /// <summary>
        /// Converting BussinessL book to DataAccessL book
        /// </summary>
        /// <param name="bookBL"></param>
        /// <returns></returns>
        public static Book ToDL(this BookBL bookBL)
        {
            Book book = new Book
            {
                Id = bookBL.Id.ToGuid(),
                ParentId = bookBL.ParentId,
                Identifier = bookBL.Identifier,
                Title = bookBL.Title,
                Author = bookBL.Author,
                Description = bookBL.Description,
                Year = bookBL.Year,
                Edition = bookBL.Edition,
                Publisher = bookBL.Publisher,
                Extension = bookBL.Extension,
                DownloadUrl = bookBL.DownloadUrl,
                CoverPicture = bookBL.CoverPicture,
                Language = bookBL.Language,
                Pages = bookBL.Pages,
            };

            return book;
        }
    }
}
