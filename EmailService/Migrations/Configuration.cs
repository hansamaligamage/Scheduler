namespace EmailService.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Text;
    internal sealed class Configuration : DbMigrationsConfiguration<EmailService.EmailServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EmailService.EmailServiceContext context)
        {

            byte[] password = Encoding.UTF8.GetBytes("password");

            context.EmailSettings.AddOrUpdate(new EmailSetting { Id = 1, Host = "smtp.gmail.com", Port = 587, UserName = "hansamaligamage@gmail.com", Password = password });

            context.EmailTemplates.AddOrUpdate(new EmailTemplate { Id = 1, Template = "Registration Email", Subject = "Registration is completed - @COMPANY",
                TemplateBody = CreateEmail.GenerateEmail("Registration is completed - @COMPANY",
                "Hello @USER, <br/> <br/> We are delighted that you have registered with our application! " +
                " <br/> <br/> Regards, <br/> @COMPANY <br/> <br/> This e-mail has been automatically generated. Please do not reply to this e-mail because the return address is invalid.")},
                new EmailTemplate { Id = 2, Template = "Reminder - vehicle service", Subject = "Reminder to service your vehicle",
                    TemplateBody = CreateEmail.GenerateEmail("Reminder to service your vehicle", "Hello @USER, <br/> <br/> It's time to service your vehicle! " +
                    " <br/> <br/> Regards, <br/> @COMPANY <br/> <br/> This e-mail has been automatically generated. Please do not reply to this e-mail because the return address is invalid.")});

            context.EmailEntries.AddOrUpdate(new EmailEntry { Id = 1, From = "hansamaligamage@gmail.com", To = "ham@exilesoft.com", EmailSettingId = 1, EmailTemplateId = 1,
                isSent = false }, new EmailEntry { Id = 2, From = "hansamaligamage@gmail.com", To = "hansamaligamage@yahoo.com", EmailSettingId = 1, EmailTemplateId = 1, isSent = false },
               new EmailEntry { Id = 3, From = "hansamaligamage@gmail.com", To = "buddhikamayadunna@gmail.com", EmailSettingId = 1, EmailTemplateId = 1, isSent = false },
               new EmailEntry { Id = 1, From = "hansamaligamage@gmail.com", To = "ham@exilesoft.com", EmailSettingId = 1, EmailTemplateId = 2, isSent = false },
               new EmailEntry { Id = 2, From = "hansamaligamage@gmail.com", To = "hansamaligamage@yahoo.com", EmailSettingId = 1, EmailTemplateId = 2, isSent = false },
               new EmailEntry { Id = 3, From = "hansamaligamage@gmail.com", To = "buddhikamayadunna@gmail.com", EmailSettingId = 1, EmailTemplateId = 2, isSent = false });

            context.SaveChanges();

            }
    }
}
