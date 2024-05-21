using BookStore.Core.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Models.Customers
{
    public class Address : BaseEntity
    {
        public string Street { get; set; } = null!;
        public string StreetNumber { get; set; } = null!;
        public string HouseNumber { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
    }
}
