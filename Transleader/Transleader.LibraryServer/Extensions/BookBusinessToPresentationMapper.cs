using Transleader.LibraryServer.BusinessL.Models;
using Transleader.LibraryServer.Models;

namespace Transleader.LibraryServer.Extensions
{
    public static class BookBusinessToPresentationMapper
    {
        /// <summary>
        /// Converting BussinessL book to PresentationL book
        /// </summary>
        /// <param name="bookBL"></param>
        /// <returns></returns>
        public static BookPL ToPL(this BookBL bookBL)
        {
            BookPL bookPL = new BookPL()
            {
                Id = bookBL.Id,
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

            return bookPL;
        }
    }
}
