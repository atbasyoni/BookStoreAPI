using BookStore.Data.Models.Helpers;

namespace BookStore.Data.Models.Products.Books
{
    public class BookAuthor : BaseModel
    {
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
