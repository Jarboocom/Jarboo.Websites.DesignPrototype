using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Domain.Pages
{
    public class JarbooPage
    {
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string DateCreated { get; set; }

        public string SeoTitle { get; set; }
        public string SeoMetaDescription { get; set; }
    }
}