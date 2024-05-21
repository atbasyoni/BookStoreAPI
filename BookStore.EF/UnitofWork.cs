using BookStore.Core;
using BookStore.Core.Interfaces;
using BookStore.Core.Models.Orders;
using BookStore.Core.Models.Products;
using BookStore.EF.Data;
using BookStore.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IBookRepository Books {  get; private set; }
        public IBaseRepository<Author> Authors {  get; private set; }
        public IBaseRepository<Genre> Genres {  get; private set; }
        public IBaseRepository<Order> Orders {  get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Books = new BookRepository(_context);
            Authors = new BaseRepository<Author>(_context);
            Genres = new BaseRepository<Genre>(_context);
            Orders = new BaseRepository<Order>(_context);
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
