using BookStore.Data.Models.Helpers;

namespace BookStore.Data.Models.Products.Books
{
    public class BookGenre : BaseModel
    {
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
