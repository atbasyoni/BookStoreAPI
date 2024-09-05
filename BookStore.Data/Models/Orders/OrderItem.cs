using BookStore.Data.Models.Helpers;
using BookStore.Data.Models.Products.Books;

namespace BookStore.Data.Models.Orders
{
    public class OrderItem : BaseModel
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
