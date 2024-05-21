using BookStore.Core.Models.Helpers;
using BookStore.Core.Models.Products.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookStore.Core.Models.Wishlist
{
    public class WishlistItem : BaseEntity
    {
        public int BookItemId { get; set; }
        [JsonIgnore]
        public virtual Book Book { get; set; }

        public int WishlistId { get; set; }
        [JsonIgnore]
        public virtual Wishlist Wishlist { get; set; }
    }
}
