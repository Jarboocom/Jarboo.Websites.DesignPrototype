using System;
using System.Collections.Generic;
using System.Linq;
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
        private const string GetAllBase = "api/get_page_index/";

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

                        var page = JsonConvert.DeserializeObject<SingleWordpressPage>(data);

                        var res = ConvertDTOToObject(page.page).FirstOrDefault();
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
            var cacheKey = _httpCacheService.GetCacheKey("Content", "GetBySpecification", specification.ToString());

            if (!_httpCacheService.ContainsKey(cacheKey))
            {
                var url = string.Format("{0}{1}", DomainBase, GetAllBase);

                using (var client = new WebClient())
                {
                    try
                    {
                        client.Encoding = Encoding.UTF8;
                        var data = client.DownloadString(url);

                        var page = JsonConvert.DeserializeObject<WordpressPageList>(data);

                        var res = ConvertDTOToObject(page.pages.ToList());
                        _httpCacheService.Create(cacheKey, res);
                        return res;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
            }

            return (List<JarbooPage>)(_httpCacheService.GetById(cacheKey));
        }

        private List<JarbooPage> ConvertDTOToObject(List<WordpressPage> pages)
        {
            List<JarbooPage> jp = new List<JarbooPage>();

            foreach (var wordpressPage in pages)
            {
                jp.AddRange(ConvertDTOToObject(wordpressPage));
            }

            return jp;

        }

        private List<JarbooPage> ConvertDTOToObject(WordpressPage page)
        {
            List<JarbooPage> jps = new List<JarbooPage>();
            var jp =  new JarbooPage
            {
                Content = page.content,
                Title = page.title,
                Slug = page.slug,
                DateCreated = page.date,
                
            };


            jps.Add(jp);

            if (page.children != null && page.children.Any())
            {
                foreach (var wordpressPage in page.children)
                {
                    jps.AddRange(ConvertDTOToObject(wordpressPage));
                }
            }
          

            return jps;

        }
    }
}