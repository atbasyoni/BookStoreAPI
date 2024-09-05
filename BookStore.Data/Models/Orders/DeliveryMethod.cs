using BookStore.Data.Models.Helpers;

namespace BookStore.Data.Models.Orders
{
    public class DeliveryMethod : DictionaryTable
    {
        public decimal Cost { get; set; }

        public List<Order> Orders { get; set; }
    }
}
