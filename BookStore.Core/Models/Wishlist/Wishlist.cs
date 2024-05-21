using BookStore.Core.Models.Customers;
using BookStore.Core.Models.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookStore.Core.Models.Wishlist
{
    public class Wishlist : BaseEntity
    {
        public int CustomerId { get; set; }

        [JsonIgnore]
        public virtual Customer Customer { get; set; }

        public List<WishlistItem>? WishlistItems { get; set; }
    }
}
