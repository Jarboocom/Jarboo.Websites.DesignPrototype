using Services.Domain.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class JarbooPageViewModel
    {
        public JarbooPageViewModel()
        {
            
        }

        public JarbooPageViewModel(JarbooPage page)
            : this()
        {
            this.Slug = page.Slug;
            this.Title = page.Title;
            this.Content = page.Content;
            this.DateCreated = page.DateCreated;

            this.SeoTitle = page.DateCreated;
            this.SeoMetaDescription = page.SeoMetaDescription;

            this.TotalCount = page.TotalCount;
            this.Pages = page.Pages;
        }

        public string Slug { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string DateCreated { get; set; }

        public string SeoTitle { get; set; }
        public string SeoMetaDescription { get; set; }

        public int TotalCount { get; set; }
        public int Pages { get; set; }

        public bool UseSidebarLayout { get; set; }
        public string GoBackUrl { get; set; }
    }
}