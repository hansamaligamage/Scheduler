using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Models
{
    public class EmailEntry
    {

        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int EmailSettingId { get; set; }
        public int EmailTemplateId { get; set; }
        public bool isSent { get; set; }
        public virtual EmailSetting EmailSetting { get; set; }
        public virtual EmailTemplate EmailTemplate { get; set; }

    }
}
