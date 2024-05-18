using BookStore.Core.DTOs;
using BookStore.Core.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.EF.Repositories
{
    public class EmailRepository(EmailConfigurationDTO  emailConfiguration) : IEmailRepository
    {
        public void SendEmail(string to, string subject, string body)
        {
            var smtpClient = ConfigureGmailSmtpClient();

            var message = CreateNewMessage(to, subject, body);

            smtpClient.Send(message);
        }

        public bool IsEmailConfigurationSet()
        {
            if(emailConfiguration.Email.IsNullOrEmpty() ||
               emailConfiguration.Password.IsNullOrEmpty() ||
               emailConfiguration.SmtpServer.IsNullOrEmpty() ||
               emailConfiguration.Port == 0
              )
            {
                return false;
            }
            return true;
        }

        private SmtpClient ConfigureGmailSmtpClient()
        {
            return new SmtpClient(emailConfiguration.SmtpServer)
            {
                Port = emailConfiguration.Port,
                Credentials = new NetworkCredential(emailConfiguration.Email, emailConfiguration.Password),
                EnableSsl = emailConfiguration.EnableSSL
            };
        }

        private MailMessage CreateNewMessage(string to, string subject, string body)
        {
            return new MailMessage(emailConfiguration.Email, to)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
        }
    }
}
