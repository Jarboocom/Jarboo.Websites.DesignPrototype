using Services.Domain.MailChimps.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.MailChimps.Lists
{
    public class SubscriberMailChimpEndpoint : BaseMailChimpEndpoint<SubscriberResource, SubscriberRequest>
    {
        public SubscriberMailChimpEndpoint(string apiKey)
            : base(apiKey)
        {

        }
    }
}
