using BookStore.Data.Models.Helpers;
using BookStore.Data.Models.Products.Books;

namespace BookStore.Data.Models.Products
{
    public class Discount : BaseModel
    {
        public string Title { get; set; }
        public decimal PercentOfDiscount { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime Description { get; set; }

        public List<BookDiscount> BookDiscounts { get; set; }
    }
}
