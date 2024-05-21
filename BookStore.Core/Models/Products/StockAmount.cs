using BookStore.Core.Models.Helpers;
using BookStore.Core.Models.Products.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Models.Products
{
    public class StockAmount : BaseEntity
    {
        public int Amount { get; set; }

        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
