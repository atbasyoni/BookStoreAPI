using Microsoft.AspNetCore.Identity;

namespace BookStore.Models
{
    public class ApplicationUser : IdentityUser
    {
        //Additional user properties
        public string FirstName { get; set; }
        public string LastName { get; set;}
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
    }
}
