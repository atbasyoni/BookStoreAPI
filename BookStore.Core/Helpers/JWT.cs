using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Helpers
{
    public class JWT
    {
        public string ValidIssuer { get; set; } = null!;
        public string ValidAudiance { get; set; } = null!;
        public double DurationInMinutes { get; set; }
        public string Key { get; set; } = null!;
    }
}
