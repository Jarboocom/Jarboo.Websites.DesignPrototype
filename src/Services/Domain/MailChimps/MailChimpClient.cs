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
        private object syncObject = new object();
        public string ApiKey { get; private set; }

        public MailChimpClient()
        {
            ApiKey = ConfigurationManager.AppSettings["MailChimpAPIKey"];
        }

        public MailChimpClient(string apiKey)
        {
            ApiKey = apiKey;
        }

        private IMailChimpEndpoint<SubscriberResource, SubscriberRequest> subscribers;
        public IMailChimpEndpoint<SubscriberResource, SubscriberRequest> Subscribers
        {
            get
            {
                lock (syncObject)
                {
                    if (subscribers == null)
                    {
                        subscribers = new SubscriberMailChimpEndpoint(ApiKey);    
                    }
                }
                return subscribers;
            }
        }
    }
}
