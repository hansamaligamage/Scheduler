using System.Data.Entity;
using EmailService.Models;

namespace EmailService
{
    public class EmailServiceContext : DbContext
    {

        public EmailServiceContext () : base("EmailServiceContext")
        {
            //System.Diagnostics.Debugger.Launch();

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EmailServiceContext>());
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public DbSet<EmailSetting> EmailSettings { get; set; }
        public DbSet<EmailEntry> EmailEntries { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }

    }
}
