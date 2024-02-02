using BookStore.Models;
using BookStore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;

        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        // GET: api/Genre
        [HttpGet]
        public async Task<ActionResult<List<Genre>>> GetGenres()
        {
            var genres = await _genreRepository.GetAllGenresAsync();
            return Ok(genres);
        }

        // GET: api/Genre/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenre(int id)
        {
            var genre = await _genreRepository.GetGenreByIdAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            return Ok(genre);
        }

        // POST: api/Genre
        [HttpPost]
        public async Task<ActionResult<Genre>> CreateGenre(Genre genre)
        {
            await _genreRepository.AddGenreAsync(genre);

            return CreatedAtAction(nameof(GetGenre), new { id = genre.Id }, genre);
        }

        // PUT: api/Genre/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(int id, Genre genre)
        {
            if (id != genre.Id)
            {
                return BadRequest();
            }

            await _genreRepository.UpdateGenreAsync(genre);

            return NoContent();
        }

        // DELETE: api/Genre/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var GenreToDelete = await _genreRepository.GetGenreByIdAsync(id);
            if (GenreToDelete == null)
            {
                return NotFound();
            }

            await _genreRepository.DeleteGenreAsync(id);

            return NoContent();
        }
    }
}
