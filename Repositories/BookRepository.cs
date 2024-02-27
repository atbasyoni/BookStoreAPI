using BookStore.DTO;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Net;

namespace BookStore.Repositories
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Books { get; set; }
        public int TotalPages { get; set; }
    }

    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<Book>> GetPagedBooks(string genre, string sort,int page)
        {
            var query = _context.Books.Include("Author").Include("Genre").AsQueryable();

            if (!string.IsNullOrEmpty(genre))
            {
                //query = query.Where(b => b.Genre == genre);
            }

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort.ToLower())
                {
                    case "priceasc":
                        query = query.OrderBy(b => b.Price);
                        break;
                    case "pricedes":
                        query = query.OrderByDescending(b => b.Price);
                        break;
                    case "titleasc":
                        query = query.OrderBy(b => b.Title);
                        break;
                    case "titledes":
                        query = query.OrderByDescending(b => b.Title);
                        break;
                }
            }

            var totalItems = query.Count();
            var totalPages = (int) Math.Ceiling((double)totalItems / 12);

            var books = await query
                .Skip((page - 1) * 12)
                .Take(12)
                .ToListAsync();

            
           return new PagedResult<Book>
           { 
               Books = books, 
               TotalPages = totalPages
           };
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _context.Books.Include("Author").Include("Genre").ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books.Include("Author").Include("Genre").FirstOrDefaultAsync(b => b.Id == id);
        }
        
        public async Task<List<Book>> GetBooksPerPageAsync(int currentPage, int itemsPerPage)
        {
            return await _context.Books
                .Skip((currentPage - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();     
        }

        public async Task<int> GetTotal()
        {
            return await _context.Books.CountAsync();
        }
        
        public async Task AddBookAsync(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookAsync(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }
    }
}
