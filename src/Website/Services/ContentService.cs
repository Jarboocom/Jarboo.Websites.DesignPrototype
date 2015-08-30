using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json;
using Website.Domain.Pages;
using Website.Domain.Pages.DTO;

namespace Website.Services
{
    public class ContentService:IContentService
    {
        private const string DomainBase = "http://blog.jarboo.com/";
        private const string ApiBase = "api/get_page?slug=";

        public ContentService()
        {

        }

        public JarbooPage GetBySlug(string slug)
        {
            var url = string.Format("{0}{1}{2}", DomainBase, ApiBase,slug);

            using (var client = new WebClient())
            {
                var data = client.DownloadString(url);

                var page = JsonConvert.DeserializeObject<WordpressPage>(data);
                return ConvertDTOToObject(page);
            }
        }

        public JarbooPage Create(JarbooPage page)
        {
            throw new NotImplementedException();
        }

        public JarbooPage Update(JarbooPage page)
        {
            throw new NotImplementedException();
        }

        public void Delete(JarbooPage page)
        {
            throw new NotImplementedException();
        }

        private JarbooPage ConvertDTOToObject(WordpressPage page)
        {
            return new JarbooPage()
            {
                Content = page.page.content,
                DateCreated = page.page.date,
                Title = page.page.title,
                Slug = page.page.slug
            };
        }
    }
}