using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services.Domain.Case;
using Services.Domain.Leads;
using Services.Services;
using Website.Domain.Case;

namespace Admin.Controllers
{
    public class CaseController : Controller
    {
        private ICaseService _caseService;
        public CaseController()
        {
            _caseService = new CaseService();
        }

        // GET: Case
        public ActionResult Index()
        {
            List<Case> cases = _caseService.GetBySpecification(new CaseSpecification()
            {
                Take = int.MaxValue
            });


            return View(cases);
        }

        public ActionResult NewCase()
        {
            return View(new Case());
        }

        public ActionResult NewCase(Case newcase)
        {
            return RedirectToAction("Index");
        }

        public ActionResult EditCase()
        {
            return null;  //View();
        }

        public ActionResult EditCase(Case newcase)
        {
            return RedirectToAction("Index");
        }
    }
}