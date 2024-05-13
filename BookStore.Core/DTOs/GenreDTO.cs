using BookStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookStore.Core.DTOs
{
    public class GenreDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
