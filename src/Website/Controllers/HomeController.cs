using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services.Domain.Case;
using Services.Services;
using Website.Models;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        private ICaseService _caseService;

        public HomeController()
        {
            _caseService = new CaseService();

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }


        public ActionResult References()
        {
            var cases = _caseService.GetBySpecification(new CaseSpecification());

            ReferencesViewModel model = new ReferencesViewModel();
            model.Cases = cases;

            return View(model);

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View(new ContactViewModel());
        }

        public ActionResult Contact(ContactViewModel model)
        {
            model.Status = "The message is sent.";
            return View(model);
        }
    }
}