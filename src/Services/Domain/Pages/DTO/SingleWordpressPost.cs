using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.Pages.DTO
{

    public class SingleWordpressPost
    {
        public string status { get; set; }
        public WordpressPost post { get; set; }
        public string previous_url { get; set; }
        public string next_url { get; set; }
    }

}