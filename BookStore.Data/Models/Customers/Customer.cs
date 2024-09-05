using BookStore.Data.Models.Accounts;
using BookStore.Data.Models.Helpers;
using BookStore.Data.Models.Wishlists;

namespace BookStore.Data.Models.Customers
{
    public class Customer : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int WishlistId { get; set; }
        public Wishlist Wishlist { get; set; }

        public List<CustomerAddress> CustomerAddresses { get; set; }
    }
}
