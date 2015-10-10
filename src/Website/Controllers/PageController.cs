using System;
using System.Web.Mvc;
using Services.Domain.Pages;
using Services.Services;
using Website.Models;
using System.Collections.Generic;
using System.Linq;
using Services.Services.Caching;

namespace Website.Controllers
{
    public class PageController : Controller
    {
        private readonly IContentService _contentService;
        private readonly IPostService _postService;
        private List<string> _useSidebarLayoutSlug = new List<string>
        {
            "resources/mandrill"
        };

        public PageController()
        {
            _contentService = new ContentService(new HttpCacheService());
            _postService = new PostService(new HttpCacheService());
        } 

        // GET: Page
        public ActionResult Index(string slug = "resources")
        {
            if (!slug.Contains("resources"))
            {
                slug = "resources/" + slug;
            }

            var page = _contentService.GetBySlug(slug);

            if (page == null)
            {
                page = _postService.GetBySlug(slug);

                if (page == null)
                {
                    return HttpNotFound();
                }
            }

            var model = new JarbooPageViewModel(page);
            model.UseSidebarLayout = true;
            model.GoBackUrl = slug != "resources" ? Url.Action("Index", "Page", new {slug = ""}) : "";
            return View(model);
        }

        public ActionResult Services(string slug = "services")
        {
            if (!slug.Contains("services"))
            {
                slug = "services/" + slug;
            }

            var page = _contentService.GetBySlug(slug);

            if (page == null)
            {
                page = _postService.GetBySlug(slug);

                if (page == null)
                {
                    return HttpNotFound();
                }
            }

            var model = new JarbooPageViewModel(page);
            model.GoBackUrl = slug != "services" ? Url.Action("Services", "Page", new { slug = "" }) : "";
            return View("Index", model);
        }

        public ActionResult Projects(string slug = "projects")
        {
            if (!slug.Contains("projects"))
            {
                slug = "projects/" + slug;
            }

            var page = _contentService.GetBySlug(slug);

            if (page == null)
            {
                page = _postService.GetBySlug(slug);

                if (page == null)
                {
                    return HttpNotFound();
                }
            }

            var model = new JarbooPageViewModel(page);
            model.UseSidebarLayout = true;
            model.GoBackUrl = slug != "projects" ? Url.Action("Projects", "Page", new { slug = "" }) : "";
            return View("Index", model);
        }

        [Route("~/blog")]
        public ActionResult Blogs(int page = 1)
        {
            const int articlesPerPage = 10;
            var spec = new PageSpecification
            {
                Take = articlesPerPage,
                Skip = (page - 1) * articlesPerPage
            };

            var blogs = _postService.GetBySpecifiction(spec);

            ViewBag.Page = page;

            return View(blogs);
        }

        [ChildActionOnly]
        public ActionResult RecentlyPosts()
        {
            const int articlesPerPage = 10;
            var spec = new PageSpecification
            {
                Take = articlesPerPage,
                Skip = 0
            };

            var blogs = _postService.GetBySpecifiction(spec);
            return PartialView("_RecentlyPosts", blogs);
        }

        public ActionResult Blog(string slug)
        {
            var page = _contentService.GetBySlug(slug);

            if (page == null)
            {
                page = _postService.GetBySlug(slug);

                if (page == null)
                {
                    return HttpNotFound();
                }
            }

            var model = new JarbooPageViewModel(page);
            model.UseSidebarLayout = true;
            model.GoBackUrl = Url.Action("Blogs", "Page");
            return View("Index", model);
        }
    }
}