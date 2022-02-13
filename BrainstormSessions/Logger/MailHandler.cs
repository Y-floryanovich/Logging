using System.IO;
using System.Net.Mail;
using log4net.Appender;
using log4net.Core;

namespace BrainstormSessions.Logger
{
    public class MailHandler
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string SmtpHost { get; set; }
        public string Port { get; set; }

        public void SendEmail(string messageBody)
        {
            SmtpClient client = new SmtpClient(SmtpHost);
            client.UseDefaultCredentials = false;
            client.Port = int.Parse(Port);
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(From);
                mailMessage.To.Add(To);
                mailMessage.Body = messageBody;
                mailMessage.Subject = Subject;
                client.Send(mailMessage);
            }
        }

    }
}
