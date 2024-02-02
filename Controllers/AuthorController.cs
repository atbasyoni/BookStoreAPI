using BookStore.Models;
using BookStore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        // GET: api/Author
        [HttpGet]
        public async Task<ActionResult<List<Author>>> GetAuthors()
        {
            var authors = await _authorRepository.GetAllAuthorsAsync();
            return Ok(authors);
        }

        // GET: api/Author/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var author = await _authorRepository.GetAuthorByIdAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        // POST: api/Author
        [HttpPost]
        public async Task<ActionResult<Author>> CreateAuthor(Author author)
        {
            if (ModelState.IsValid)
            {
                await _authorRepository.AddAuthorAsync(author);
                return Ok(author);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Author/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }

            await _authorRepository.UpdateAuthorAsync(author);

            return NoContent();
        }

        // DELETE: api/Author/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var authorToDelete = await _authorRepository.GetAuthorByIdAsync(id);
            if (authorToDelete == null)
            {
                return NotFound();
            }

            await _authorRepository.DeleteAuthorAsync(id);

            return NoContent();
        }
    }
}
