using BookStore.Core.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Models
{
    public class Publisher : DictionaryTable
    {
        public string Description { get; set; }
    }
}
