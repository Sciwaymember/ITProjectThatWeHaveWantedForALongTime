using Microsoft.AspNetCore.Mvc;
using Transleader.LibraryServer.BusinessL.Repositories;
using Transleader.LibraryServer.BusinessL.Models;
using Transleader.LibraryServer.Extensions;
using Transleader.LibraryServer.Models;
using Transleader.LibraryServer.DataAccessL.Types;

namespace Transleader.LibraryServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryController : ControllerBase
    {      
        private readonly ILogger<LibraryController> _logger;

        private readonly IRepository<BookBL> _db;

        public LibraryController(ILogger<LibraryController> logger, IRepository<BookBL> db)
        {
            _logger = logger;
            _db = db;
        }

        //Endpoint of getting book by id
        [HttpGet(Name = "GetBook")]
        public async Task<BookPL?> Get(string id)
        {
            BookBL? bookBL = await _db.ReadAsync(Uid.Parse(id));
            BookPL? book = bookBL != null ? bookBL.ToPL() : null;

            return book;
        }

        //Endpoint of creating new db element
        [HttpPost(Name = "CreateBook")]
        public async void Post(BookPL bookPL)
        {
            BookBL bookBL = bookPL.ToNewBL();
            await _db.CreateAsync(bookBL);
        }
    }
}