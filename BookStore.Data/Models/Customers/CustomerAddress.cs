using BookStore.Data.Models.Helpers;

namespace BookStore.Data.Models.Customers
{
    public class CustomerAddress : BaseModel
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
