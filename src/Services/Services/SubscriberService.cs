using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Domain.Subscribers;
using System.Configuration;
using Services.Domain.MailChimps;
using Services.Domain.MailChimps.Lists;
using Services.Domain.MailChimps.DTO;
using log4net;

namespace Services.Services
{
    public class SubscriberService : ISubscriberService
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(SubscriberService));
        private MailChimpClient _mailChimpClient { get; set; }
        private string listId = ConfigurationManager.AppSettings["MailChimpListId"];
        private const string JARBOO_PLA = "JARBOO_PLA";
        public SubscriberService()
        {
            _mailChimpClient = new MailChimpClient();    
        }

        public void Subscribe(Subscriber subscriber)
        {
            var addSubscriberRequest = new AddSubscriberRequest(listId);
            addSubscriberRequest.EmailAddress = subscriber.Email;
            addSubscriberRequest.Status = SubscriberStatus.Subscribed;
            addSubscriberRequest.MergeFields = new Dictionary<string, object>() { { JARBOO_PLA, subscriber.JarbooPlacement } };

            try
            {
                _mailChimpClient.Subscribers.Post(addSubscriberRequest);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        public void Unsubscribe(Subscriber subscriber)
        {
            throw new NotImplementedException();
        }
    }
}
