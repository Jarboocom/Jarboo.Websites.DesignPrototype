using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Services.Domain.MailChimps.DTO
{
    public class SubscriberStats
    {
        [JsonProperty("avg_open_rate")]
        public int AvgOpenRate { get; set; }

        [JsonProperty("avg_click_rate")]
        public int AvgClickRate { get; set; }
    }
}
