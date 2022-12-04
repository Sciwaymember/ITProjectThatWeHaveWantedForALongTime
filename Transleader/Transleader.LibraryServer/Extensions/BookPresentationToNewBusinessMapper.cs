using Transleader.LibraryServer.BusinessL.Models;
using Transleader.LibraryServer.DataAccessL.Types;
using Transleader.LibraryServer.Models;

namespace Transleader.LibraryServer.Extensions
{
    public static class BookPresentationToNewBusinessMapper
    {
        /// <summary>
        /// Converting PresentationL book to BussinessL book
        /// </summary>
        /// <param name="bookPL"></param>
        /// <returns></returns>
        public static BookBL ToNewBL(this BookPL bookPL)
        {
            BookBL bookBL = new BookBL
            {
                Id = Uid.NewGuid(),
                ParentId = bookPL.ParentId,
                Identifier = bookPL.Identifier,
                Title = bookPL.Title,
                Author = bookPL.Author,
                Description = bookPL.Description,
                Year = bookPL.Year,
                Edition = bookPL.Edition,
                Publisher = bookPL.Publisher,
                Extension = bookPL.Extension,
                DownloadUrl = bookPL.DownloadUrl,
                CoverPicture = bookPL.CoverPicture,
                Language = bookPL.Language,
                Pages = bookPL.Pages,
            };

            return bookBL;
        }
    }
}
