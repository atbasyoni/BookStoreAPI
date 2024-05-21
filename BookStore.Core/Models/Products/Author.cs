using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BookStore.Core.Models.Helpers;
using BookStore.Core.Models.Products.Books;

namespace BookStore.Core.Models.Products
{
    public class Author : DictionaryTable
    {
        public string Bio { get; set; }
        public string? Image { get; set; }
    }
}
