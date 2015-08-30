using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Domain.Leads
{
    public enum LeadStatus
    {
        New=0,
        InContact=10,
        Done=50
    }
}