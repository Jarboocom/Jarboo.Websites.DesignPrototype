using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Services.Domain.MailChimps.Lists
{
    public class AddSubscriberRequest : SubscriberRequest
    {
        public AddSubscriberRequest(string listId)
            : base(listId)
        {
        }

        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("merge_fields")]
        public Dictionary<string, object> MergeFields { get; set; }
    }
}
