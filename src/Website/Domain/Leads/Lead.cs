using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Domain.Leads
{
    public class Lead
    {
        public int Id { get; set; }
        public LeadStatus LeadStatus { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        // Customer info
        public string Email { get; set; }
        public string Skype { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string Name { get; set; }

        // Project
        public string ProjectDeadline { get; set; }
        public string ProjectDescription { get; set; }
    }
}