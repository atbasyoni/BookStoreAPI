using BookStore.Core.Interfaces;
using BookStore.Core.Models.Orders;
using BookStore.Core.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository Books { get; }
        IBaseRepository<Author> Authors { get; }
        IBaseRepository<Genre> Genres { get; }
        IBaseRepository<Order> Orders { get; }
        Task<int> Complete();
    }
}
