using BookStore.Data.Models.Helpers;
using BookStore.Data.Models.Products.Books;

namespace BookStore.Data.Models.Products
{
    public class Publisher : DictionaryTable
    {
        public string Description { get; set; }

        public List<Book> Books { get; set; }
    }
}
