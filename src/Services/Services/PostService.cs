using System;
using System.Net;
using Newtonsoft.Json;
using Services.Domain.Pages;
using Services.Domain.Pages.DTO;

namespace Services.Services
{
    public class PostService : IPostService
    {
        private const string DomainBase = "http://blog.jarboo.com/";
        private const string ApiBase = "api/get_post?slug=";


        public JarbooPage GetBySlug(string slug)
        {
            var url = string.Format("{0}{1}{2}", DomainBase, ApiBase, slug);

            try
            {
                using (var client = new WebClient())
                {
                    var data = client.DownloadString(url);

                    var page = JsonConvert.DeserializeObject<WordpressPost>(data);
                    return ConvertDTOToObject(page);
                }
            }
            catch (Exception)
            {
                return null;
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

        private JarbooPage ConvertDTOToObject(WordpressPost page)
        {
            return new JarbooPage
            {
                Content = page.post.content,
                DateCreated = page.post.date,
                Title = page.post.title,
                Slug = page.post.slug
            };
        }
    }
}
