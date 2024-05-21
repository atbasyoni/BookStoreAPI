using BookStore.Core.Models.Customers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Models.Accounts
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; } = null!;

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public List<RefreshToken> RefreshTokens { get; set; } = null!;
    }
}
