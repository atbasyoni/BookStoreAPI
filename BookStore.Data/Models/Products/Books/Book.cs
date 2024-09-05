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