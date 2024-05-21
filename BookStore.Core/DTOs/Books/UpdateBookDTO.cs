using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.DTOs.Books
{
    public class UpdateBookDTO
    {
        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(13)]
        [RegularExpression(@"^\d{10}(\d{3})?$", ErrorMessage = "Invalid ISBN format.")]
        public string ISBN { get; set; }

        [MaxLength(2)]
        public string Language { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The number of pages must be greater than zero.")]
        public int Pages { get; set; }

        [Range(0.0, double.MaxValue, ErrorMessage = "Price must be a non-negative value.")]
        public decimal Price { get; set; }

        public DateTime PublicationDate { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative value.")]
        public int Quantity { get; set; }

        public int PublisherId { get; set; }

        public List<int> AuthorIds { get; set; }
        public List<int> GenreIds { get; set; }
        public List<string> ImageUrls { get; set; }
    }
}
