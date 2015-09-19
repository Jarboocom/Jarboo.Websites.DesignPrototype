using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Domain.Subscribers;
using System.Configuration;
using Services.Domain.MailChimps;

namespace Services.Services
{
    public class SubscriberService : ISubscriberService
    {
        private MailChimpClient mailChimpClient { get; set; }

        public SubscriberService()
        {
            this.mailChimpClient = new MailChimpClient();    
        }

        public void Subscribe(string email)
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe(string email)
        {
            throw new NotImplementedException();
        }
    }
}
