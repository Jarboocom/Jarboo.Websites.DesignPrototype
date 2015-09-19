using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class SubscriberViewModel
    {
        public string Email { get; set; }
        public string Subcribe { get; set; }
        public string JarbooPlacement { get; set; }
        public string RedirectUrl { get; set; }
        public string ReturnUrl { get; set; }
    }
}