using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Services.Domain.Case;

namespace Website.Models
{
    public class ReferencesViewModel
    {
        public List<Case> Cases { get; set; }

        public ReferencesViewModel()
        {
            this.Cases = new List<Case>();
        }
    }
}