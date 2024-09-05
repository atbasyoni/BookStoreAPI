using BookStore.Data.Models.Helpers;

namespace BookStore.Data.Models.Customers
{
    public class Address : BaseModel
    {
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public List<CustomerAddress> CustomerAddresses { get; set; }
    }
}
