using Services.Domain.MailChimps.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.MailChimps.Lists
{
    public class ListsMailChimpEndpoint : BaseMailChimpEndpoint<ListResource, ListRequest>
    {
        public ListsMailChimpEndpoint(string apiKey)
            : base(apiKey)
        {

        }
    }
}
