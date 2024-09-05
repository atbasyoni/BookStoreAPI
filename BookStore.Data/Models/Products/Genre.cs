using BookStore.Data.Models.Helpers;
using BookStore.Data.Models.Products.Books;

namespace BookStore.Data.Models.Products
{
    public class Genre : DictionaryTable
    {
        public List<BookGenre> BookGeners { get; set; }
    }
}
