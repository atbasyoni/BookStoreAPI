using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.DTOs.Authors
{
    public class AuthorBookDTO
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }
    }
}
