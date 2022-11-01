using Microsoft.AspNetCore.Mvc;
using Transleader.LibraryServer.Models;

namespace Transleader.LibraryServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryController : ControllerBase
    {
       
        private readonly ILogger<LibraryController> _logger;

        public LibraryController(ILogger<LibraryController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetBooksSearchResult")]
        public IEnumerable<BookView> Get()
        {
            DataBaseStub dataContext = new DataBaseStub();

            return dataContext.Books.ToArray();
        }
    }
}