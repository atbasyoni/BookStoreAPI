using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Models.Helpers
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
