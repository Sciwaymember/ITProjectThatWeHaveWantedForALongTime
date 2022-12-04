using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transleader.LibraryServer.DataAccessL.Models;
using Transleader.LibraryServer.DataAccessL.Types;

namespace Transleader.LibraryServer.DataAccessL.Extensions
{
    public static class LibgenToCompactMapper
    {
        public static BookCompact ToCompact(this BookLg bookLg)
        {
            BookCompact bookCompact = new BookCompact()
            {
                Id = Uid.Parse(bookLg.Id),
                ParentId = bookLg.ParentId,
                Title = bookLg.Title,
                Author = bookLg.Author,
                CoverPicture = "http://library.lol/covers/" + bookLg.Coverurl,
                Source = Source.Libgen
            };

            return bookCompact;
        }
    }
}
