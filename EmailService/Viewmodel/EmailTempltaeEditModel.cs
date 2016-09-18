using System.Collections.Generic;

namespace EmailService.Viewmodel
{
    public class EmailTempltaeEditModel
    {

        public int EmailSettingId { get; set; }

        public string Subject { get; set; }

        public string EmailTemplate { get; set; }

        public string From { get; set; }

        public List<string> To { get; set; }

    }
}
