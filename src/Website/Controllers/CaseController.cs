using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services.Domain.Case;
using Services.Services;

namespace Website.Controllers
{
    public class CaseController : Controller
    {
        private ICaseService _caseService;
        public CaseController()
        {
            _caseService = new CaseService();
        }

        // GET: Case
        [Route("Index/{slug}")]
        public ActionResult Index(string slug)
        {
            var our_case = _caseService.GetBySlug(slug);



            return View(our_case);
        }
    }
}