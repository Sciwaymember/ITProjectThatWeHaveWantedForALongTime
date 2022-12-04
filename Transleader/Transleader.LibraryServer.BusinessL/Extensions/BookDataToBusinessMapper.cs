using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transleader.LibraryServer.BusinessL.Models;
using Transleader.LibraryServer.DataAccessL.Models;
using Transleader.LibraryServer.DataAccessL.Types;

namespace Transleader.LibraryServer.BusinessL.Extensions
{
    public static class BookDataToBusinessMapper
    {
        /// <summary>
        /// Converting DataAccessL book to BussinessL book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public static BookBL ToBL(this Book book)
        {
            BookBL bookBL = new BookBL
            {
                Id = Uid.Parse(book.Id),
                ParentId = book.ParentId,
                Identifier = book.Identifier,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Year = book.Year,
                Edition = book.Edition,
                Publisher = book.Publisher,
                Extension = book.Extension,
                DownloadUrl = book.DownloadUrl,
                CoverPicture = book.CoverPicture,
                Language = book.Language,
                Pages = book.Pages,
            };

            return bookBL;
        }
    }
}
