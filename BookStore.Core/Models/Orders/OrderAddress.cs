using BookStore.Core.Models.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Models.Orders
{
    public class OrderAddress
    {
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
    }
}
