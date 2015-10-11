using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using Services.Domain.Pages;
using Services.Domain.Pages.DTO;
using Services.Services.Caching;
using ServiceStack.Text;

namespace Services.Services
{
    public class PostService : IPostService
    {
        private const string DomainBase = "http://blog.jarboo.com/";
        private const string SingleApiBase = "api/get_post?slug=";
        private const string MultipleApiBase = "api/get_posts?";

        private readonly HttpCacheService _httpCacheService;

        public PostService(HttpCacheService httpCacheService)
        {
            _httpCacheService = httpCacheService;
        }


        public JarbooPage GetBySlug(string slug)
        {
            var url = string.Format("{0}{1}{2}", DomainBase, SingleApiBase, slug);

            var cacheKey = _httpCacheService.GetCacheKey("Content", "GetBySlug", slug);

            if (!_httpCacheService.ContainsKey(cacheKey))
            {
                try
                {
                    using (var client = new WebClient())
                    {
                        var data = client.DownloadString(url);

                        var page = JsonConvert.DeserializeObject<SingleWordpressPost>(data);

                        var res = ConvertDTOToObject(page.post);

                        _httpCacheService.Create(cacheKey, res);

                        return res;

                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }

            return (JarbooPage)(_httpCacheService.GetById(cacheKey));

        
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

        public List<JarbooPage> GetBySpecification(ContentSpecification specification)
        {
            throw new NotImplementedException();
        }


        public List<JarbooPage> GetBySpecifiction(PageSpecification specification)
        {
            var cacheKey = _httpCacheService.GetCacheKey("PostContent", "GetBySlug", specification.ToString());

            if (!_httpCacheService.ContainsKey(cacheKey))
            {

                var result = new List<JarbooPage>();
                var url = string.Format("{0}{1}posts_per_page={2}&offset={3}", DomainBase, MultipleApiBase, specification.Take, specification.Skip);
                try
                {
                    using (var client = new WebClient())
                    {
                        var data = client.DownloadString(url);

                        var blog = JsonConvert.DeserializeObject<WordpressPostList>(data);

                        result.AddRange(blog.posts.Select(s => new JarbooPage
                        {
                            Content = s.content,
                            DateCreated = s.date,
                            Title = s.title,
                            Slug = s.slug,
                            Pages = blog.pages,
                            TotalCount = blog.count_total
                        }));

                        var res = result;

                        _httpCacheService.Create(cacheKey, res);

                        return res;
                    }
                }
                catch (Exception)
                {
                    return result;
                }

            }

            return (List<JarbooPage>) (_httpCacheService.GetById(cacheKey));

          
        }

        private JarbooPage ConvertDTOToObject(WordpressPost page)
        {
            return new JarbooPage
            {
                Content = page.content,
                DateCreated = page.date,
                Title = page.title,
                Slug = page.slug
            };
        }


    }
}
