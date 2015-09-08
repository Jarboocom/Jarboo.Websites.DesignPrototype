using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using Services.Domain.Pages;
using Services.Domain.Pages.DTO;
using ServiceStack.Text;

namespace Services.Services
{
    public class PostService : IPostService
    {
        private const string DomainBase = "http://blog.jarboo.com/";
        private const string SingleApiBase = "api/get_post?slug=";
        private const string MultipleApiBase = "api/get_posts?";


        public JarbooPage GetBySlug(string slug)
        {
            var url = string.Format("{0}{1}{2}", DomainBase, SingleApiBase, slug);

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

        public List<JarbooPage> GetBySpecifiction(PageSpecification specification)
        {
            var result = new List<JarbooPage>();
            var url = string.Format("{0}{1}posts_per_page={2}&offset={3}", DomainBase, MultipleApiBase, specification.Take, specification.Skip);
            try
            {
                using (var client = new WebClient())
                {
                    var data = client.DownloadString(url);

                    var blog = JsonConvert.DeserializeObject<WordpressBlog>(data);

                    result.AddRange(blog.posts.Select(s => new JarbooPage
                    {
                        Content = s.content,
                        DateCreated = s.date,
                        Title = s.title,
                        Slug = s.slug,
                        Pages = blog.pages,
                        TotalCount = blog.count_total
                    }));

                    return result;
                }
            }
            catch (Exception)
            {
                return result;
            }
        }

        private JarbooPage ConvertDTOToObject(Page page)
        {
            return new JarbooPage
            {
                Content = page.content,
                DateCreated = page.date,
                Title = page.title,
                Slug = page.slug
            };
        }

        private JarbooPage ConvertDTOToObject(WordpressPost page)
        {
            return ConvertDTOToObject(page.post);
        }
    }
}
