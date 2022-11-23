using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transleader.LibraryServer.BusinessL.Models;
using Transleader.LibraryServer.DataAccessL.Models;

namespace Transleader.LibraryServer.BusinessL.Extensions
{
    public static class MapDataToModel
    {
        /// <summary>
        /// Converting DataAccessL book to BussinessL book
        /// </summary>
        /// <param name="bookData"></param>
        /// <returns></returns>
        public static BookModel MapToModel(this Book bookData)
        {
            BookModel book = new BookModel
            {
                Id = bookData.Id, // make it nullable if exception
                ParentId = bookData.ParentId,
                Title = bookData.Title,
                Author = bookData.Author,
                CoverPicture = bookData.CoverPicture
            };

            return book;
        }
    }
}
