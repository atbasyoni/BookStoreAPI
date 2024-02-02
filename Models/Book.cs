using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookStore.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Title { get; set; }

        [Required]
        [MaxLength(10)]
        public string? ISBN { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        public int Pages { get; set; }

        [Required]
        public string? Language { get; set; }

        [Required]
        public string? Image { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }

        // Foreign keys
        public int AuthorId { get; set; }

        public int GenreId { get; set; }

        // Navigation properties
        [ForeignKey("AuthorId")]
        [JsonIgnore]
        public virtual Author? Author { get; set; }

        [ForeignKey("GenreId")]
        [JsonIgnore]
        public virtual Genre? Genre { get; set; }

        [JsonIgnore]
        public virtual List<Review>? Reviews { get; set; }

        [JsonIgnore]
        public virtual List<OrderItem>? OrderItems { get; set; }
    }
}
