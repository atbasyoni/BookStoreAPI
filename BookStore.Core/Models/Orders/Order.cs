using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BookStore.Core.Models.Customers;

namespace BookStore.Core.Models.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public int OrderStatusId { get; set; }
        [JsonIgnore]
        public virtual OrderStatus OrderStatus { get; set; }

        public int DeliveryMethodId { get; set; }
        [JsonIgnore]
        public virtual DeliveryMethod DeliveryMethod { get; set; }

        public int CustomerId { get; set; }
        [JsonIgnore]
        public virtual Customer Customer { get; set; }

        public int OrderAddressId { get; set; }
        [JsonIgnore]
        public virtual OrderAddress OrderAddress { get; set; }
    }
}
