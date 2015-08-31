using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services.Domain.Pages;
using Services.Services;

namespace Website.Controllers
{
    public class PageController : Controller
    {
        private IContentService _contentService;

        public PageController()
        {
            _contentService = new ContentService();
        } 

        // GET: Page
        public ActionResult Index(string slug)
        {
            var page = _contentService.GetBySlug(slug);

            return View(page);
        }
    }
}