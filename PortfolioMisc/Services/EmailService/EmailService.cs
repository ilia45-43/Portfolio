using MimeKit;
using MailKit.Net.Smtp;
using PortfolioMisc.Models;

namespace PortfolioMisc.Services.EmailService
{
    public class EmailService : IEmailService
    {
        public void SendGmail(EmailModel emailModel)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress($"{emailModel.Name}", ""));
            message.To.Add(new MailboxAddress("", "ilia377841@gmail.com"));
            message.Body = new BodyBuilder() { HtmlBody = $"<div>Телефон для связи: " +
                $" {emailModel.Subject}</div><div>Почта для связи: {emailModel.Email}</div> " +
                $"<div>{emailModel.Message}</div>"}.ToMessageBody();

            using (MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate("ilia377841@gmail.com", "Не скажу");
                client.Send(message);

                client.Disconnect(true);
            }


        }
    }
}
