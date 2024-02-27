using BookStore.Models;

namespace BookStore.Repositories
{
    public interface IReviewRepository
    {
        Task AddReviewAsync(Review review);
        Task DeleteReviewAsync(int id);
        Task<List<Review>> GetAllReviewsAsync();
        Task<Review> GetReviewByIdAsync(int id);
        Task UpdateReviewAsync(Review review);
    }
}