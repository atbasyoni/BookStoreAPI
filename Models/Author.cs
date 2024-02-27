using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookStore.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Bio { get; set; }

        // Navigation property
        [JsonIgnore]
        public virtual List<Book> Books { get; set; }
    }
}
