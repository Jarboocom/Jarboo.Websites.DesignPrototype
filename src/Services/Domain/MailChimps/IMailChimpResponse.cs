using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.MailChimps
{
    public interface IMailChimpResponse
    {
        Dictionary<string, object> Headers { get; set; }
    }
}
