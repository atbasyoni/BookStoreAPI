using BookStore.Data.Models.Customers;
using BookStore.Data.Models.Products;
using BookStore.Data.Models.Products.Books;

namespace BookStore.Data.Models.Helpers
{
    public class Image : BaseModel
    {
        public string Title { get; set; }
        public string URL { get; set; }
        public int Position { get; set; } = 1;

        public List<Author> Authors { get; set; }
        public List<BookImage> BookImages { get; set; }
    }
}
