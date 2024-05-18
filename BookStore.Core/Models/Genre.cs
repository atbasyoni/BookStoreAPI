using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BookStore.Core.Models.Products.Books;

namespace BookStore.Core.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Book>? Books { get; set; }
    }
}
