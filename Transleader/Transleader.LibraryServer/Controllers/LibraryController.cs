using Microsoft.AspNetCore.Mvc;
using Transleader.LibraryServer.DataAccessL;
using Transleader.LibraryServer.DataAccessL.Models;
using Transleader.LibraryServer.Models;

namespace Transleader.LibraryServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryController : ControllerBase
    {
       
        private readonly ILogger<LibraryController> _logger;

        private readonly BookDbContext _context;

        public LibraryController(ILogger<LibraryController> logger, BookDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetBooksSearchResult")]
        public IEnumerable<Book> Get()
        {
            _context.Books.Add(new Book {Author = "Gregory Davids", Title = "Shantaram" });
            _context.SaveChanges();
            return _context.Books.ToArray();
        }
    }
}