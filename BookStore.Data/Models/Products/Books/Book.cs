using BookStore.Data.Models.Helpers;

namespace BookStore.Data.Models.Products.Books
{
    public class Book : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string Language { get; set; }
        public int Pages { get; set; }
        public decimal Price { get; set; }
        public DateTime PublicationDate { get; set; }
        public int StockAmount { get; set; }
        public int SoldUnits { get; set; } = 0;

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public List<BookDiscount> BookDiscounts { get; set; }
        public List<BookAuthor> BookAuthors { get; set; }
        public List<BookGenre> BookGenres { get; set; }
        public List<BookImage> BookImages { get; set; }
    }
}
/*
 [Required(ErrorMessage = "Title is required.")]
 [MaxLength(200)]
 [MaxLength(500)]
 [MaxLength(13)]
 [RegularExpression(@"^\d{10}(\d{3})?$", ErrorMessage = "Invalid ISBN format.")]
 [MaxLength(2)]
 [Range(1, int.MaxValue, ErrorMessage = "The number of pages must be greater than zero.")]
 [Range(0.0, double.MaxValue, ErrorMessage = "Price must be a non-negative value.")]
 [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative value.")]
 [Range(0, int.MaxValue, ErrorMessage = "Sold units must be a non-negative value.")]
 */