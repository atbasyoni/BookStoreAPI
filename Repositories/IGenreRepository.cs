using BookStore.Models;

namespace BookStore.Repositories
{
    public interface IGenreRepository
    {
        Task AddGenreAsync(Genre genre);
        Task DeleteGenreAsync(int id);
        Task<List<Genre>> GetAllGenresAsync();
        Task<Genre> GetGenreByIdAsync(int id);
        Task UpdateGenreAsync(Genre genre);
    }
}
