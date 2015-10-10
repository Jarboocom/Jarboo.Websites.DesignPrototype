using System;
using System.Web.Mvc;
using Mandrill;
using Mandrill.Model;
using Services.Domain.Case;
using Services.Domain.Subscribers;
using Services.Services;
using Website.Models;
using log4net;
using Services.Services.Caching;

namespace Website.Controllers
{
    [RoutePrefix("home")]
    public class HomeController : Controller
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof (HomeController));
        private readonly ICaseService _caseService;
        private readonly ISubscriberService _subscriberService;
        public HomeController()
        {
            _caseService = new CaseService(new HttpCacheService());
            _subscriberService = new SubscriberService();
        }

        public ActionResult Index()
        {
            const int topCasesCount = 2;
            var cases = _caseService.GetBySpecification(new CaseSpecification{Take = topCasesCount});

            var model = new HomeViewModel
            {
                Cases = cases
            };

            return View(model);
        }

        [Route("~/gratis-radgivning")]
        public ActionResult GratisRadgivning()
        {
            return View();
        }

        [Route("~/free-advice")]
        public ActionResult FreeAdvice()
        {
            return View();
        }

        [Route("~/ebook")]
        public ActionResult EbookSignup()
        {
            return View();
        }

        [Route("~/about")]
        public ActionResult About()
        {
            return View();
        }

        [Route("~/email-maybe")]
        public ActionResult EmailMaybe()
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

        [Route("~/not-found")]
        public ActionResult NotFound()
        {
            return View("404");
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
                return RedirectToAction("ThankYou");
            }
            
            return View(model);
        }

        public ActionResult ThankYou()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Subscribe(SubscriberViewModel model)
        {
            try
            {
                _subscriberService.Subscribe(new Subscriber
                {
                    Email = model.Email,
                    JarbooPlacement = model.JarbooPlacement
                });

                if (string.IsNullOrEmpty(model.RedirectUrl)) return RedirectToAction("ThankYou");
                return Redirect(model.RedirectUrl);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
            
            return Redirect(model.ReturnUrl);
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