using BookStore.Models;
using BookStore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        // GET: api/Review
        [HttpGet]
        public async Task<ActionResult<List<Review>>> GetReviews()
        {
            var reviews = await _reviewRepository.GetAllReviewsAsync();
            return Ok(reviews);
        }

        // GET: api/Review/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            var review = await _reviewRepository.GetReviewByIdAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        // POST: api/Review
        [HttpPost]
        public async Task<ActionResult<Review>> CreateReview(Review review)
        {
            await _reviewRepository.AddReviewAsync(review);

            return CreatedAtAction(nameof(GetReview), new { id = review.Id }, review);
        }

        // PUT: api/Review/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, Review review)
        {
            if (id != review.Id)
            {
                return BadRequest();
            }

            await _reviewRepository.UpdateReviewAsync(review);

            return NoContent();
        }

        // DELETE: api/Review/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var reviewToDelete = await _reviewRepository.GetReviewByIdAsync(id);
            if (reviewToDelete == null)
            {
                return NotFound();
            }

            await _reviewRepository.DeleteReviewAsync(id);

            return NoContent();
        }
    }
}
