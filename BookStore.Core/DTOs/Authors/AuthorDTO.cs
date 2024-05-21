using BookStore.Core.DTOs.Helpers;
using BookStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookStore.Core.DTOs.Authors
{
    public class AuthorDTO : BaseDictionaryDTO
    {
        public string? Bio { get; set; }
        public string? Image { get; set; }
    }
}
