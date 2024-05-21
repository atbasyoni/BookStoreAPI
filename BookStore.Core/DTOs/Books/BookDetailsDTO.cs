using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Core.DTOs.Authors;

namespace BookStore.Core.DTOs.Books
{
    public class BookDetailsDTO : BookDTO
    {
        public PublisherDTO Publisher { get; set; }
        public List<AuthorDTO> Authors { get; set; }
        public List<GenreDTO> Genres { get; set; }
        public List<string> ImagesURLs { get; set; }
        //public List<BookDiscountDTO> Discounts { get; set; }
    }
}
