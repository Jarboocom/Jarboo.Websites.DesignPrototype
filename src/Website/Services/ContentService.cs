using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Website.Domain;

namespace Website.Services
{
    public class ContentService
    {
        private const string DomainBase = "http://blog.jarboo.com/";
        private const string ApiBase = "api/get_page_index?slug=";

        public ContentService()
        {

        }

        public JarbooPage GetBySlug(string slug)
        {
            var url = string.Format("{0}{1}", DomainBase, ApiBase);

            using (var client = new WebClient())
            {
                var data = client.DownloadString(url);


            }
        }

    }
}