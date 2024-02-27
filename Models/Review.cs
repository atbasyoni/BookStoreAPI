using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        // Foreign key
        public int BookId { get; set; }

        // Navigation property
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
    }
}
