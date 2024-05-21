using BookStore.Core.DTOs.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.DTOs
{
    internal class PublisherDTO : BaseDictionaryDTO
    {
        public string? Description { get; set; }
    }
}
