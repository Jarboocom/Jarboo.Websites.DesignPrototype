using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Domain.MailChimps;
using Services.Domain.MailChimps.DTO;
using Services.Domain.MailChimps.Lists;

namespace Tests
{
    [TestClass]
    public class ListsEndpointTests
    {
        [TestMethod]
        public void New_Subscriber_Is_Added()
        {
            MailChimpClient client = new MailChimpClient(Constants.ApiKey);

            var request = new AddSubscriberRequest(Constants.ListId);
            request.EmailAddress = "hellangle381@gmail.com";
            request.Status = SubscriberStatus.Subscribed;
            request.MergeFields = new Dictionary<string, object>() { { "subscribe", "GET FREE PDF" }, { "JARBOO_PLA", "GetPdfEbook" } };
            var response = client.Lists.Post(request);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsNotNull(response.Result.Id);
        }
    }
}
