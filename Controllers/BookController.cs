//New Controller
using Microsoft.AspNetCore.Mvc;

namespace ControllerAPI2
{
    //Data Model
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
    }
    [ApiController]
    //[Route("/api/book")]
    [Route("/api/[controller]")]
    public class BookController : ControllerBase
    {
        //New list
        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "Book 1", Author = "Author 1" },
            new Book { Id = 2, Title = "Book 2", Author = "Author 2" },
            new Book { Id = 3, Title = "Book 3", Author = "Author 3" },
        };
        //Endpoint for return list
        [HttpGet("[action]")]
        public IActionResult List()
        {
            return Ok(books);
        }
        //Endpoint: Get by id
        [HttpGet("[action]/{id}")]
        public IActionResult Get(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        //Endpoint: for add book
        [HttpPost("[action]")]
        public IActionResult Create([FromBody] Book newBook)
        {
            return Ok("HttpPost Doing");
        }
        //Endpoint: Add new book in list
        [HttpPost("[action]")]
        public IActionResult Create2([FromBody] Book newBook)
        {
            newBook.Id = books.Max(b => b.Id) + 1;
            books.Add(newBook);
            return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
        }
        //Endpoint: Update book
        [HttpPut("[action]/{id}")]
        public IActionResult Update(int id, [FromBody] Book updatedBook)
        {
            var existingBook = books.FirstOrDefault(b => b.Id == id);
            if (existingBook == null)
            {
                return NotFound();
            }
            existingBook.Title = updatedBook.Title;
            existingBook.Author = updatedBook.Author;
            return Ok(existingBook);
        }
        //Endpoint: Delete book
        [HttpDelete("[action]/{id}")]
        public IActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            books.Remove(book);
            return NoContent();
        }

        //Endpoint:
        [HttpGet]
        [Route("[action]")]
        public IActionResult Index()
        {
            return Ok(new { message = "index" });
        }
        //Endpoint:
        [HttpGet]
        [Route("Info/{name}")]
        public IActionResult Info(string name)
        {
            return Ok(new { message = "info", name = name });
        }
        //Endpoint:Multi Parameters
        [HttpGet]
        [Route("Multi/{name}/{age}")]
        public IActionResult Multi(string name, int age)
        {
            return Ok(new { message = "multiParam", name = name, age = age });
        }
        //Endpoint: Add route in HttpGet
        [HttpGet("GetValue")]
        public IActionResult GetValue()
        {
            return Ok(new { message = "getValue" });
        }
        //Endpoint: many parameters
        [HttpGet("Query1")]
        public IActionResult Query1()
        {
            var value = HttpContext.Request.Query["value"].ToString();
            var age = HttpContext.Request.Query["age"].ToString();
            return Ok(new { value = value, age = age });
        }
        //Endpoint: many parameters option 2
        [HttpGet("Query2")]
        public IActionResult Query2([FromQuery] string value)
        {
            return Ok(value);
        }

    }
}