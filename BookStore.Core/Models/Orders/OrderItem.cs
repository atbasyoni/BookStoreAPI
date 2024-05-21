using BookStore.Core.Models.Helpers;
using BookStore.Core.Models.Products.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookStore.Core.Models.Orders
{
    public class OrderItem : BaseEntity
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }

        public int BookItemId { get; set; }

        [JsonIgnore]
        public virtual Book Book { get; set; }

        public int OrderId { get; set; }

        [JsonIgnore]
        public virtual Order Order { get; set; }
    }
}
