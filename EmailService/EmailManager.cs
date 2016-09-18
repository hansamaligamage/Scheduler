using EmailService;
using EmailService.Models;
using EmailService.Viewmodel;
using NLog;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmailApp
{
    public class EmailManager
    {

        EmailServiceContext emailServiceContext = new EmailServiceContext();

        private static Logger logger = LogManager.GetCurrentClassLogger();

        // check whether to list is practical.
        public List<EmailViewModel> GetEmails ()
        {
            List<EmailViewModel> emailEntries = emailServiceContext.EmailEntries.Where(e => e.isSent == false).Select(s => new EmailViewModel {EmailEntryId = s.Id, From = s.From,
                To = s.To, Subject = s.EmailTemplate.Subject, Body = s.EmailTemplate.TemplateBody }).ToList();
            return emailEntries;
        }

        public EmailSettingViewModel GetEmailSettings ()
        {
            EmailSetting emailSetting = emailServiceContext.EmailSettings.FirstOrDefault(p => p.Host == "smtp.gmail.com");
            return new EmailSettingViewModel { Host = emailSetting.Host, Port = emailSetting.Port, UserName = emailSetting.UserName, Password = Encoding.Default.GetString(emailSetting.Password) };
        }

        public bool ChangeEmailStatus (int entryId)
        {
            bool isSuccess = false;
            EmailEntry entry = emailServiceContext.EmailEntries.FirstOrDefault(e => e.Id == entryId);
            if(entry != null)
            {
                entry.isSent = true;
                isSuccess = emailServiceContext.SaveChanges() > 0;
            }
            return isSuccess;
        }


    }
}
