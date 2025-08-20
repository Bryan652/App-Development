using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Codes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InputController : ControllerBase
    {
        // Sample data
        public static List<Input> books = new List<Input>
        {
            new Input { Id = 1, Name = "Do Nothing"},
            new Input { Id = 2, Name = "Grammar 101"},
            new Input { Id = 3, Name = "Read people like a book"},
            new Input { Id = 3, Name = "Read people like a book"},
            new Input { Id = 3, Name = "Serpent Dove"}
        };

        // GET: api/books
        [HttpGet]
        public ActionResult<IEnumerable<Input>> GetInput()
        {
            return Ok(books);
        }
    }

    public class Input
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
