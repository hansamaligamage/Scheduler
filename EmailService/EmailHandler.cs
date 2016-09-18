using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using EmailService;
using NLog;

namespace EmailApp
{
    public static class EmailHandler
    {

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static bool SendEmail(string host, int port, string username, string password, string fromAddress, List<string> toAddress, string subject, string body)
        {
            bool emailSent = false;
            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromAddress);
            foreach (string address in toAddress)
                message.To.Add(address);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            var client = new SmtpClient(host, Convert.ToInt32(port))
            {
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true
                
            };
            try
            {
                client.Send(message);
                emailSent = true;

                logger.Info(string.Format("Email sent from {0} to {1}", fromAddress, string.Join(",", toAddress)));
            }
            catch (Exception ex)
            {
                emailSent = false;
                logger.Error(ExceptionHandler.ToLongString(ex));
            }
            return emailSent;
        }

        
    }
}
