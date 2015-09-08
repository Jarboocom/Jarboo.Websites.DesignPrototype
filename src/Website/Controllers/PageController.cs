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
    }
}