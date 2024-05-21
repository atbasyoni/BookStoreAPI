using BookStore.Core.Models.Helpers;
using BookStore.Core.Models.Products.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookStore.Core.Models.Products
{
    public class Discount : BaseEntity
    {
        public string Title { get; set; }
        public decimal PercentOfDiscount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime Description { get; set; }

        [JsonIgnore]
        public List<Book>? Books { get; set; }

        [JsonIgnore]
        public List<BookDiscount>? BookDiscounts { get; set; }
    }
}
