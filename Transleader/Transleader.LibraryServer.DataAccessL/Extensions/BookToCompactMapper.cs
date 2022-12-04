using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transleader.LibraryServer.DataAccessL.Models;
using Transleader.LibraryServer.DataAccessL.Types;

namespace Transleader.LibraryServer.DataAccessL.Extensions
{
    public static class BookToCompactMapper
    {
        public static BookCompact ToCompact(this Book book)
        {
            BookCompact bookCompact = new BookCompact()
            {
                Id = Uid.Parse(book.Id),
                ParentId = book.ParentId,
                Title = book.Title,
                Author = book.Author,
                CoverPicture = book.CoverPicture,
                Source = Source.Local
            };

            return bookCompact;
        }
    }
}
