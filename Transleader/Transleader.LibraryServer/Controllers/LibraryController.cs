using Microsoft.AspNetCore.Mvc;
using Transleader.LibraryServer.BusinessL.Repositories;
using Transleader.LibraryServer.BusinessL.Models;
using Transleader.LibraryServer.Extensions;
using Transleader.LibraryServer.Models;

namespace Transleader.LibraryServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryController : ControllerBase
    {      
        private readonly ILogger<LibraryController> _logger;

        private readonly IRepository<BookModel> _fabric;

        public LibraryController(ILogger<LibraryController> logger, IRepository<BookModel> fabric)
        {
            _logger = logger;
            _fabric = fabric;
        }

        //Endpoint of getting book by id
        [HttpGet(Name = "GetBook")]
        public async Task<BookView?> Get(int id)
        {
            BookModel? bookModel = await _fabric.Read(id);
            BookView? book = null;

            if (bookModel != null)
            {
                book = bookModel.MapToView();
            }

            return book;
        }

        //Endpoint of creating new db element
        [HttpPost(Name = "CreateBook")]
        public async void Post(BookView book)
        {
            BookModel bookModel = book.MapToModel();
            await _fabric.Create(bookModel);
        }
    }
}