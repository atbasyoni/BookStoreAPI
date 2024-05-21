using BookStore.Core.Interfaces;
using BookStore.Core.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.EF.Repositories
{
    public class EmailSenderRepository : IEmailSenderRepository
    {
        private readonly IEmailRepository _emailRepository;

        public EmailSenderRepository(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }

        public void ConfirmEmail(string token, ApplicationUser user)
        {
            if (_emailRepository.IsEmailConfigurationSet())
            {
                var confirmationLink = "";
                var emailBody = $"To confirm your email address, click <a href='{confirmationLink}'>here</a>.";
                _emailRepository.SendEmail(user.Email, "Confirm Email Address", emailBody);
            }
        }

        public void ResetPasswordEmail(string token, ApplicationUser user)
        {
            if(_emailRepository.IsEmailConfigurationSet())
            {
                var resetLink = "";
                var emailBody = $"To reset your password, click <a href='{resetLink}'>here</a>.";
                _emailRepository.SendEmail(user.Email, "Reset Password", emailBody);
            }
        }
    }
}
