using BookStore.Data.Models.Helpers;
using BookStore.Data.Models.Products.Books;

namespace BookStore.Data.Models.Products
{
    public class Author : DictionaryTable
    {
        public string Bio { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }

        public List<BookAuthor> BookAuthors { get; set; }
    }
}
