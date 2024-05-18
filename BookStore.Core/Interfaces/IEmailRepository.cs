using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Interfaces
{
    public interface IEmailRepository
    {
        public void SendEmail(string to, string subject, string body);
        public bool IsEmailConfigurationSet();
    }
}
