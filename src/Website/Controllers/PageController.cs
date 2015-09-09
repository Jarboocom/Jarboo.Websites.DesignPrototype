using System.Web.Mvc;
using Services.Domain.Pages;
using Services.Services;

namespace Website.Controllers
{
    public class PageController : Controller
    {
        private readonly IContentService _contentService;
        private readonly IPostService _postService;

        public PageController()
        {
            _contentService = new ContentService();
            _postService = new PostService();
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

            return View(page);
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

            return View("Index", page);
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

            return View("Index", page);
        }
    }
}