using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.MailChimps.DTO
{
    public class SubscriberStatus
    {
        public static readonly string Subscribed = "subscribed";
        public static readonly string Unsubscribed = "unsubscribed";
        public static readonly string Cleaned = "cleaned";
        public static readonly string Pending = "pending";
    }
}
