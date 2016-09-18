using EmailApp;
using EmailService.Viewmodel;
using NLog;
using System.Collections.Generic;

namespace EmailScheduler
{
    public static class ProcessEmail
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static bool IsRun = false;


        public static bool CreateEmail ()
        {
            bool isSuccess = false;

            if (!ProcessEmail.IsRun)
            {
                IsRun = true;
                //logger.Log(LogLevel.Info, "create email");
                //System.Diagnostics.Debugger.Launch();
                EmailManager emailManager = new EmailManager();
                //EmailHandler emailHandler = new EmailHandler();
                List<EmailViewModel> emailViewModel = emailManager.GetEmails();
                EmailSettingViewModel emailSettingViewModel = emailManager.GetEmailSettings();
                foreach (EmailViewModel viewmodel in emailViewModel)
                {
                    //isSuccess = EmailHandler.SendEmail(viewmodel.From, new List<string>() { viewmodel.To }, "mail subject", "mail body");
                    isSuccess = EmailHandler.SendEmail(emailSettingViewModel.Host, emailSettingViewModel.Port, emailSettingViewModel.UserName, emailSettingViewModel.Password,
                        viewmodel.From, new List<string>() { viewmodel.To }, viewmodel.Subject, viewmodel.Body);
                    isSuccess = emailManager.ChangeEmailStatus(viewmodel.EmailEntryId);
                }
                ProcessEmail.IsRun = false;
            }
            return isSuccess;
        }
        

    }
}
