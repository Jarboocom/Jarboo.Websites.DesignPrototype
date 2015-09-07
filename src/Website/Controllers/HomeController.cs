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
using Website.Models.ExtensionMethods;

namespace Website.Controllers
{
    [RoutePrefix("home")]
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

        [Route("~/about")]
        public ActionResult About()
        {
            return View();
        }

        [Route("~/references")]
        public ActionResult References()
        {
            const int topReferenceCases = 4;
            var cases = _caseService.GetBySpecification(new CaseSpecification { Take = topReferenceCases });

            ReferencesViewModel model = new ReferencesViewModel
            {
                Cases = cases
            };

            return View(model);

        }

        [Route("~/contact")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View(new ContactViewModel());
        }

        public ActionResult NewsletterSignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("~/contact")]

        public ActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var result = MandrillSendExtension.customSend(model, MandrillTemplates.Invoice);
                Send(model);
                model.Status = "The message is sent.";
            }
            
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

            message.AddGlobalMergeVars("EMAIL", model.Email);
            message.AddGlobalMergeVars("MESSAGE", model.Message);
            var result = api.Messages.SendTemplate(message, "jarboo-contact-form");
        }
    }
}