using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.DTOs.Authors
{
    public class UpdateAuthorDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        public string Bio { get; set; }

        public string? Image { get; set; }
    }
}
