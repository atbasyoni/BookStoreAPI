using BookStore.Core.Models.Helpers;
using BookStore.Core.Models.Products.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Models.Products.BookItems
{
    public class BookItem : BaseEntity
    {
        public double Score { get; set; } = 0;
        public decimal Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The number of pages must be greater than zero.")]
        public int Pages { get; set; }

        [MaxLength(13)]
        public string ISBN { get; set; }

        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }


    }
}
