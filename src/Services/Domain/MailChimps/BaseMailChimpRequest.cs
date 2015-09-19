using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.MailChimps
{
    public abstract class BaseMailChimpRequest
    {
        public string Id { get; set; }
        public string Url { get; set; }
    }
}
