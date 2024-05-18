using BookStore.Core.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Models.Orders
{
    public class DeliveryMethod : DictionaryTable
    {
        public decimal Price { get; set; }
    }
}
