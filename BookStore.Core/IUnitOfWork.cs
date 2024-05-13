using BookStore.Core.Interfaces;
using BookStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Book> Books { get; }
        IBaseRepository<Author> Authors { get; }
        IBaseRepository<Genre> Genres { get; }
        Task<int> Complete();
    }
}
