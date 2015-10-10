using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Services.Domain.Pages;
using Services.Domain.Pages.DTO;
using Services.Services.Caching;

namespace Services.Services
{
    public class ContentService:IContentService
    {
        private const string DomainBase = "http://blog.jarboo.com/";
        private const string ApiBase = "api/get_page?slug=";
        private readonly HttpCacheService _httpCacheService;

        public ContentService(HttpCacheService httpCacheService)
        {
            _httpCacheService = httpCacheService;
        }

        public JarbooPage GetBySlug(string slug)
        {
            var cacheKey = _httpCacheService.GetCacheKey("Content", "GetBySlug", slug);

            if (!_httpCacheService.ContainsKey(cacheKey))
            {
                var url = string.Format("{0}{1}{2}", DomainBase, ApiBase, slug);

                using (var client = new WebClient())
                {
                    try
                    {
                        client.Encoding = Encoding.UTF8;
                        var data = client.DownloadString(url);

                        var page = JsonConvert.DeserializeObject<WordpressPage>(data);

                        var res = ConvertDTOToObject(page);
                        _httpCacheService.Create(cacheKey, res);
                        return res;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
            }

            return (JarbooPage) (_httpCacheService.GetById(cacheKey));

         
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

        private JarbooPage ConvertDTOToObject(WordpressPage page)
        {
            return new JarbooPage
            {
                Content = page.page.content,
                DateCreated = page.page.date,
                Title = page.page.title,
                Slug = page.page.slug
            };
        }
    }
}