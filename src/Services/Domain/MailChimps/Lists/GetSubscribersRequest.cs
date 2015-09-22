using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.MailChimps.Lists
{
    public class GetSubscribersRequest : SubscriberRequest
    {
        public GetSubscribersRequest(string listId)
            : base(listId)
        {
        }

        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }
    }
}
