using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Domain.Case
{
    public class Case
    {
        public int Id { get; set; }
        public string DownloadUrl { get; set; }

        public string Slug { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        
    }
}