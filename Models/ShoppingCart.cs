using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }

        // Navigation property
        public virtual List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
