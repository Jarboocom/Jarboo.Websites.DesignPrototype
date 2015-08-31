using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mandrill;
using Mandrill.Model;
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

        public ActionResult PostContact(ContactViewModel model)
        {
            Send(model);
            model.Status = "The message is sent.";
            return View(model);
        }

        private void Send(ContactViewModel model)
        {
            var api = new MandrillApi("IRWMe1g1dCTrG6uOZEy7gQ");
            var message = new MandrillMessage();
            message.FromEmail = "info@jarboo.com";
            message.AddTo("lh@jarboo.com");
            message.ReplyTo = "info@jarboo.com";
            //supports merge var content as string
            message.AddGlobalMergeVars("NAME", model.Name);

            message.AddGlobalMergeVars("EMAIL", model.Email);
            message.AddGlobalMergeVars("MESSAGE", model.Message);
            var result = api.Messages.SendTemplate(message, "customer-invoice");
        }
    }
}