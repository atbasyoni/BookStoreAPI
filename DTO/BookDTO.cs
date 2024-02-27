using BookStore.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookStore.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public string Language { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int PublicationDate { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }
    }
}
