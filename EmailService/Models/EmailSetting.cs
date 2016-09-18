using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Models
{
    public class EmailSetting
    {

        public int Id { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public byte[] Password { get; set; }

        public virtual ICollection<EmailEntry> EmailEntries { get; set; }

    }
}
