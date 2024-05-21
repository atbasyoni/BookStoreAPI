using BookStore.Core.Models.Products.Books;
using BookStore.Core.Models.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BookStore.Core.DTOs.Helpers;

namespace BookStore.Core.DTOs.Books
{
    public class BookDTO : BaseDTO
    {
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ISBN { get; set; }

        public string Language { get; set; } = null!;

        public int Pages { get; set; }

        public decimal Price { get; set; }

        public DateTime PublicationDate { get; set; }

        public int Quantity { get; set; }

        public int SoldUnits { get; set; } = 0;

        public int PublisherId { get; set; }
    }
}
