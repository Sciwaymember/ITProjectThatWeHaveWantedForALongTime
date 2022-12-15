using Transleader.LibraryServer.BusinessL.Models;
using Transleader.LibraryServer.DataAccessL.Models;
using Transleader.LibraryServer.DataAccessL.Types;

namespace Transleader.LibraryServer.BusinessL.Extensions
{
    public static class BookLibgenToBusinessMapper
    {
        public static BookBL ToBL(this BookLg bookLg)
        {
            BookBL bookBL = new BookBL()
            {
                Id = Uid.Parse(bookLg.Id),
                ParentId = bookLg.ParentId,
                Identifier = bookLg.Identifier,
                Title = bookLg.Title,
                Author = bookLg.Author,
                Description = bookLg.Description,
                Year = bookLg.Year,
                Edition = bookLg.Edition,
                Publisher = bookLg.Publisher,
                Extension = bookLg.Extension,
                DownloadUrl = "http://libgen.is/get.php?md5=" + bookLg.Md5, //TODO Settings class
                CoverPicture = "http://library.lol/covers/" + bookLg.Coverurl, //TODO Settings class
                Language = bookLg.Language,
                Pages = bookLg.Pages,
            };

            return bookBL;
        }
    }
}
