using BookStore.Data.Models.Customers;
using BookStore.Data.Models.Helpers;

namespace BookStore.Data.Models.Orders
{
    public class Order : BaseModel
    {
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public int DeliveryMethodId { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
