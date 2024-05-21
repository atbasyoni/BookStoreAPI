using BookStore.Core.DTOs.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.DTOs.Authors
{
    public class AuthorDetailsDTO : AuthorDTO
    {
        public List<BookDTO> Books { get; set; }
    }
}
