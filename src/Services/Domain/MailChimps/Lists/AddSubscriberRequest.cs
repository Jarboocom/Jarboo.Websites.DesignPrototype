using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Services.Domain.MailChimps.Lists
{
    public class AddSubscriberRequest : BaseMailChimpRequest
    {
        public AddSubscriberRequest(string listId)
        {
            Url = string.Format("lists/{0}/members", listId);
        }

        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("merge_fields")]
        public Dictionary<string, object> MergeFields { get; set; }
    }
}
