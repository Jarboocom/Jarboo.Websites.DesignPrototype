using System.Web.Mvc;
using Services.Domain.Case;
using Services.Services;
using Services.Services.Caching;

namespace Website.Controllers
{
    public class CaseController : Controller
    {
        private readonly ICaseService _caseService;
        public CaseController()
        {
            _caseService = new CaseService(new HttpCacheService());
        }

        // GET: Case
        public ActionResult Index(string slug)
        {
            var our_case = _caseService.GetBySlug(slug);

            if (our_case != null)
            {
                return View(our_case);
            }

            return new HttpNotFoundResult();
        }
    }
}