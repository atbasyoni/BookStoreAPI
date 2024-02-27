using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookStore.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        // Navigation property
        [JsonIgnore]
        public virtual List<Book> Books { get; set; }
    }
}
