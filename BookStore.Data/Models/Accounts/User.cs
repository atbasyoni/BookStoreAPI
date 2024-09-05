using BookStore.Data.Models.Customers;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Data.Models.Accounts
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<RefreshToken> RefreshTokens { get; set; }
    }
}
