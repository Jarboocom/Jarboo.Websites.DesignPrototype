using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.MailChimps
{
    public abstract class BaseMailChimpResponse<T> : IMailChimpResponse
    {
        protected BaseMailChimpResponse()
        {
            Headers = new Dictionary<string, object>();
        }

        public Dictionary<string, object> Headers { get; set; }

        public T Result { get; set; }
    }
}
