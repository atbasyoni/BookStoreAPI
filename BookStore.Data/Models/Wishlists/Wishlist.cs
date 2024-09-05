using BookStore.Data.Models.Customers;
using BookStore.Data.Models.Helpers;

namespace BookStore.Data.Models.Wishlists
{
    public class Wishlist : BaseModel
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<WishlistItem> WishlistItems { get; set; }
    }
}
