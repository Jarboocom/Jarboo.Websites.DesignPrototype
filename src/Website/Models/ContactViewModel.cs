using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class ContactViewModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }

        public string Message { get; set; }

        public string Status { get; set; }

    }
}