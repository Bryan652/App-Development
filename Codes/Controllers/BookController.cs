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

        // POST: api/students
        [HttpPost]
        public ActionResult<Books> Create(Books book)
        {
            if (book == null)
                return BadRequest(); // 400 Bad Request

            book.Id = books.Count > 0 ? books.Max(s => s.Id) + 1 : 1;
            books.Add(book);

            // 201 Created with Location header
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Books updatedBooks)
        {
            if (updatedBooks == null || updatedBooks.Id != id)
                return BadRequest(); // 400 Bad Request

            var existingBooks = books.FirstOrDefault(s => s.Id == id);
            if (existingBooks == null)
                return NotFound(); // 404 Not Found

            existingBooks.Name = updatedBooks.Name;

            return NoContent(); // 204 No Content
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = books.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound(); // 404 Not Found

            books.Remove(student);
            return NoContent(); // 204 No Content
        }
    }
    public class Books
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}



