using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using PortfolioMisc.Models;

namespace PortfolioMisc.Services.EmailService
{
    public class EmailService : IEmailService
    {
        public void SendGmail(EmailModel emailModel)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress($"{emailModel.name}", ""));
            message.To.Add(new MailboxAddress("", "ilia377841@gmail.com"));
            message.Body = new BodyBuilder() { HtmlBody = $"<div>Телефон для связи: " +
                $" {emailModel.mobileNumber}</div><div>Почта для связи: {emailModel.email}</div> " +
                $"<div>{emailModel.message}</div>"}.ToMessageBody();

            using (MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate("ilia377841@gmail.com", "НЕ скажу");
                client.Send(message);

                client.Disconnect(true);
            }
        }
    }
}
