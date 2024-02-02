using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitPrice { get; set; }

        // Foreign keys
        [Required]
        public int BookId { get; set; }

        [Required]
        public int OrderId { get; set; }

        // Navigation properties
        [ForeignKey("BookId")]
        public virtual Book? Book { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order? Order { get; set; }

    }
}
