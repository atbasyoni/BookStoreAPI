using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookStore.Core.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Bio { get; set; }
        public string? Image { get; set; }
        public List<Book>? Books { get; set; }
    }
}
