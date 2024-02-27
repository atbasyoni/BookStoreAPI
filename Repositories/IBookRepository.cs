using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Repositories
{
    public interface IBookRepository
    {
        Task<PagedResult<Book>> GetPagedBooks(string genre, string sort, int page);
        Task AddBookAsync(Book book);
        Task DeleteBookAsync(int id);
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<List<Book>> GetBooksPerPageAsync(int currentPage, int itemsPerPage);
        Task<int> GetTotal();
        Task UpdateBookAsync(Book book);
    }
}
