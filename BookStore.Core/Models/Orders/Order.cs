using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Core.Models.Customers;

namespace BookStore.Core.Models.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public int OrderStatusId { get; set; }
        [ForeignKey("OrderStatusId")]
        public virtual OrderStatus OrderStatus { get; set; }

        public int DeliveryMethodId { get; set; }
        [ForeignKey("DeliveryMethodId")]
        public virtual DeliveryMethod DeliveryMethod { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public int OrderAddressId { get; set; }
        [ForeignKey("OrderAddressId")]
        public virtual OrderAddress OrderAddress { get; set; }
    }
}
