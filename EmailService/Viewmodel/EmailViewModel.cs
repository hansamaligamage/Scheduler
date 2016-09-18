using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmailService.Viewmodel
{
    public class EmailViewModel
    {

        [JsonProperty(PropertyName = "emailEntryId")]
        public int EmailEntryId { get; set; }
        [JsonProperty(PropertyName = "from")]
        public string From { get; set; }
        [JsonProperty(PropertyName = "to")]
        public string To { get; set; }
        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }
        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

    }
}
