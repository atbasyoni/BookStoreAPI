using BookStore.Models;

namespace BookStore.Repositories
{
    public interface IBookRepository
    {
        Task AddBookAsync(Book book);
        Task DeleteBookAsync(int id);
        Task<List<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);
        Task UpdateBookAsync(Book book);
    }
}
