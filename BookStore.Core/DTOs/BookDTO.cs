using BookStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookStore.Core.DTOs
{
    public class BookDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ISBN { get; set; }
        public string? Description { get; set; }
        public int Pages { get; set; }
        public string? Language { get; set; }
        public string? Image { get; set; }
        public decimal Price { get; set; }
        public DateTime PublicationDate { get; set; }
        public int Quantity { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
    }
}
