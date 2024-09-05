using BookStore.Data.Models.Helpers;
using BookStore.Data.Models.Products.Books;

namespace BookStore.Data.Models.Wishlists
{
    public class WishlistItem : BaseModel
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int WishlistId { get; set; }
        public Wishlist Wishlist { get; set; }
    }
}
