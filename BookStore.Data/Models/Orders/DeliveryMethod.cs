using BookStore.Data.Models.Helpers;

namespace BookStore.Data.Models.Orders
{
    public class DeliveryMethod : DictionaryTable
    {
        public string Description { get; set; }
        public string DeliveryTime { get; set; }
        public decimal Cost { get; set; }
        public List<Order> Orders { get; set; }
    }
}
