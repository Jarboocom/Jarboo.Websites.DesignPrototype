using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services.Domain.Case;
using Services.Domain.Pages;
using Services.Services;
using Services.Services.Caching;
using SimpleMvcSitemap;

namespace Website.Controllers
{
    public class SitemapController : Controller
    {
        private readonly ICaseService _caseService;
        private readonly IPostService _postService;
        private readonly IContentService _contentService;


        public SitemapController()
        {
            _caseService = new CaseService(new HttpCacheService());
            _postService = new PostService(new HttpCacheService());
            _contentService = new ContentService(new HttpCacheService());
        }

        // GET: Sitemap
        public ActionResult Index()
        {
            List<SitemapNode> nodes = new List<SitemapNode>
            {
                new SitemapNode(Url.Action("Index","Home")),
                new SitemapNode(Url.Action("About","Home")),
                new SitemapNode(Url.Action("EbookSignup","Home")),
                new SitemapNode(Url.Action("Contact","Home")),
                new SitemapNode(Url.Action("GratisRadgivning","Home")),
                new SitemapNode(Url.Action("EmailMaybe","Home")),
                new SitemapNode(Url.Action("FreeAdvice","Home")),
                new SitemapNode(Url.Action("NewsletterSignUp","Home")),
                new SitemapNode(Url.Action("References","Home")),
                new SitemapNode(Url.Action("Subscribe","Home")),
                new SitemapNode(Url.Action("ThankYou","Home")),
            };

            var cases = _caseService.GetBySpecification(new CaseSpecification()
            {
                Take = int.MaxValue
            });

            var posts = _postService.GetBySpecifiction(new PageSpecification()
            {
                Take = int.MaxValue
            });

            var content = _contentService.GetBySpecification(new ContentSpecification()
            {
                Take = int.MaxValue
            });

            foreach (var our_case in cases)
            {
                nodes.Add(new SitemapNode(Url.Action("Index","Case",new { slug  = our_case.Slug})));
            }

            foreach (var our_post in posts)
            {
                nodes.Add(new SitemapNode(Url.Action("Blog","Page",new { slug =our_post.Slug})));
            }

            // get blog pages overview

            foreach (var our_page in content)
            {
                nodes.Add(new SitemapNode(Url.Action("Index","Page",new {slug= our_page.Slug })));
            }

            return new SitemapProvider().CreateSitemap(HttpContext, nodes);
        }
    }
}