using BookStore.Data.Models.Helpers;

namespace BookStore.Data.Models.Products.Books
{
    public class BookDiscount : BaseModel
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int DiscountId { get; set; }
        public Discount Discount { get; set; }
    }
}
