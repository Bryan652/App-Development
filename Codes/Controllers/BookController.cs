using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Codes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        // Sample data
        public static List<Books> books = new List<Books>
        {
            new Books { Id = 1, Name = "Do Nothing"},
            new Books { Id = 2, Name = "Grammar 101"},
            new Books { Id = 3, Name = "Read people like a book"}
        };

        // GET: api/books
        [HttpGet]
        public ActionResult<IEnumerable<Books>> GetBooks()
        {
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Books> GetById(int id)
        {
            var book = books.FirstOrDefault(s => s.Id == id);
            if (book == null)
                return NotFound(); // 404 Not Found

            return Ok(book); // 200 OK
        }


    }
    public class Books
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}