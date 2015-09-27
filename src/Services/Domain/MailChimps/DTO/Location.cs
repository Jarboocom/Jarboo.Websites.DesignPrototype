using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.MailChimps.DTO
{
    public class Location
    {
        [JsonProperty("latitude")]
        public Decimal Latitude { get; set; }

        [JsonProperty("longitude")]
        public Decimal Longitude { get; set; }

        [JsonProperty("gmtoff")]
        public int Gmtoff { get; set; }

        [JsonProperty("dstoff")]
        public int Dstoff { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    }
}
