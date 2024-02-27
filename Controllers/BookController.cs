using BookStore.Models;
using BookStore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        /*
        // GET: api/book
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return Ok(books);
        }
        */
        // GET: api/book
        [HttpGet]
        public async Task<IActionResult> GetBooksPerPage(
            [FromQuery] string genre = null,
            [FromQuery] string sort = null,
            [FromQuery] int page = 1)
        {       
            PagedResult<Book> p = await _bookRepository.GetPagedBooks(genre, sort, page);
            return Ok(new { p.Books, p.TotalPages });
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return Ok(books);
        }

        // GET: api/book/5
        [HttpGet("{id}", Name = "Get Book by Id")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        /*
        // GET: api/book
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks([FromQuery] int currentPage, [FromQuery] int itemsPerPage)
        {
            var books = await _bookRepository.GetBooksPerPageAsync(currentPage, itemsPerPage);
            int totalItems = await _bookRepository.GetTotal();

            return Ok(new { books, totalItems });
        }
        */

        // POST: api/book
        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(Book book)
        {
            await _bookRepository.AddBookAsync(book);

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        // PUT: api/book/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            await _bookRepository.UpdateBookAsync(book);

            return NoContent();
        }

        // DELETE: api/book/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var bookToDelete = await _bookRepository.GetBookByIdAsync(id);
            if (bookToDelete == null)
            {
                return NotFound();
            }

            await _bookRepository.DeleteBookAsync(id);

            return NoContent();
        }
    }
}
