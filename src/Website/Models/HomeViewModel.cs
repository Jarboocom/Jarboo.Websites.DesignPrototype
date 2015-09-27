using System.Collections.Generic;
using Services.Domain.Case;

namespace Website.Models
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            Cases = new List<Case>();
        }

        public List<Case> Cases { get; set; }
    }
}