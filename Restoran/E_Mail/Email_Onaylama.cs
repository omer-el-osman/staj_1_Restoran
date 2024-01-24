using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Restoran.E_Mail
{
    public class Email_Onaylama: IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var mail = "tmr200677@gmail.com";
            var pass = "mltrnptrsoeihhcm";

            var mess = new MailMessage();
            mess.From = new MailAddress(mail);
            mess.Subject = subject;
            mess.To.Add(email);
            mess.Body = $"<html><Body>{htmlMessage}</Body></html>";
            mess.IsBodyHtml = true;

            var smt = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,

                Credentials = new NetworkCredential(mail, pass),

                EnableSsl = true


            };

            smt.Send(mess);


        }
    }
}
