using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.Subscribers
{
    public interface ISubscriberService
    {
        void Subscribe(Subscriber subscriber);
        void Unsubscribe(Subscriber subscriber);
    }
}
