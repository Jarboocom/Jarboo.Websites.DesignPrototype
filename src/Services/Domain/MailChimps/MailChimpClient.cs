using Services.Domain.MailChimps.Lists;
using Services.Services.MailChimps.Lists;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.MailChimps
{
    public class MailChimpClient
    {
        public string ApiKey { get; private set; }

        public MailChimpClient()
        {
            ApiKey = ConfigurationManager.AppSettings["MailChimpAPIKey"];
        }

        public MailChimpClient(string apiKey)
        {
            ApiKey = apiKey;
        }

        public IMailChimpEndpoint<ListResource, ListRequest> Lists
        {
            get
            {
                return new ListsMailChimpEndpoint(ApiKey);
            }
        }
    }
}
