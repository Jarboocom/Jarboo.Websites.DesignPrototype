using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Services.Domain.MailChimps
{
    public abstract class BaseMailChimpRequest
    {
        [JsonIgnore]
        public string Url { get; set; }
    }
}
