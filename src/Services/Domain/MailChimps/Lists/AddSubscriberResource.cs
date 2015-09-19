using Newtonsoft.Json;
using Services.Domain.MailChimps.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.MailChimps.Lists
{
    public class AddSubscriberResource : BaseMailChimpResource
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }

        [JsonProperty("unique_email_id")]
        public string unique_email_id { get; set; }

        [JsonProperty("email_type")]
        public string EmailType { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("merge_fields")]
        public Dictionary<string, string> MergeFields { get; set; }

        [JsonProperty("stats")]
        public SubscriberStats Stats { get; set; }

        [JsonProperty("ip_signup")]
        public string IpSignup { get; set; }

        [JsonProperty("timestamp_signup")]
        public DateTime? TimestampSignup { get; set; }

        [JsonProperty("ip_opt")]
        public string IpOpt { get; set; }

        [JsonProperty("timestamp_opt")]
        public DateTime TimestampOpt { get; set; }

        [JsonProperty("member_rating")]
        public int MemberRating { get; set; }

        [JsonProperty("last_changed")]
        public DateTime LastChanged { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("vip")]
        public bool Vip { get; set; }

        [JsonProperty("email_client")]
        public string EmailClient { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("list_id")]
        public string ListId { get; set; }

        [JsonProperty("_links")]
        public List<Link> Links { get; set; }
    }
}
