using BookStore.Core.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Interfaces
{
    public interface IEmailSenderRepository
    {
        void ResetPasswordEmail(string token, ApplicationUser user);
        void ConfirmEmail(string token, ApplicationUser user);
    }
}
