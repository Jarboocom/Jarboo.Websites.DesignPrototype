using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.MailChimps.Lists
{
    public abstract class SubscriberRequest : BaseMailChimpRequest
    {
        protected SubscriberRequest(string listId)
        {
            Url = string.Format("lists/{0}/members", listId);
        }
    }
}
