using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BookStore.Core.Models.Helpers;

namespace BookStore.Core.Models.Products.Books
{
    public class Book : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Language { get; set; }

        public int PublisherId { get; set; }
        public virtual Publisher? Publisher { get; set; }
        public List<BookAuthor>? BookAuthors { get; set; }
        public List<BookGenre>? BookGenres { get; set; }
        public List<BookImage>? BookImages { get; set; }
    }
}
