using EmailService.Viewmodel;
using NLog;
using System.Collections.Generic;

namespace EmailApp
{
    class Program
    {

        private static Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            EmailManager e = new EmailManager();
            List<EmailViewModel> v = e.GetEmails();

        }
    }
}
