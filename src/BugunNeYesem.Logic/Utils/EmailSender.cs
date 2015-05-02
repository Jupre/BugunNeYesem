using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace BugunNeYesem.Logic.Utils
{
    public class EmailSender : IEmailSender
    {
        private readonly string _sender;
        private readonly string _password;
        private readonly string _smtpHost;
        private readonly int _smtpPort;
        private readonly bool _enableSsl;

        public EmailSender(string sender, string password, string smtpHost, int smtpPort, bool enableSsl)
        {
            _sender = sender;
            _password = password;
            _smtpHost = smtpHost;
            _smtpPort = smtpPort;
            _enableSsl = enableSsl;
        }

        public EmailSender()
        {
            _sender = ConfigurationManager.AppSettings["SMTP_EMAIL"];
            _password = ConfigurationManager.AppSettings["SMTP_PWD"];
            _smtpHost = ConfigurationManager.AppSettings["SMTP_HOST"];
            _smtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["SMTP_PORT"]);
            _enableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["SMTP_SSL"]);
        }

        public void Send(string to, string subject, string body)
        {
            var client = new SmtpClient
            {
                Credentials = new NetworkCredential(_sender, _password),
                Port = _smtpPort,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = _enableSsl,
                Host = _smtpHost
            };

            var mail = new MailMessage(new MailAddress(_sender, "Bugün Ne Yesem"), new MailAddress(to))
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            client.Send(mail);
        }
    }
}