using BookStore.Data.Models.Helpers;

namespace BookStore.Data.Models.Products.Books
{
    public class BookImage : BaseModel
    {
        public int ImageId { get; set; }
        public Image Image { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
