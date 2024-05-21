using BookStore.Core.DTOs;
using BookStore.Core.Interfaces;
using BookStore.Core.Models.Products.Books;
using BookStore.EF.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.EF.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context) { }
    }
}
