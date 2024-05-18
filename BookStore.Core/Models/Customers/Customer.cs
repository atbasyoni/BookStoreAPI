using BookStore.Core.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Models.Customers
{
    public class Customer : BaseEntity
    {
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public List<CustomerAddress>? CustomerAddresses { get; set; }
    }
}
