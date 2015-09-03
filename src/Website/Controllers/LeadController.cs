using System.Web.Mvc;
using Services.Domain.Leads;
using Services.Services;

namespace Website.Controllers
{
    public class LeadController : Controller
    {
        private readonly ILeadService _leadService;
        public LeadController()
        {
            _leadService = new LeadService();
        }

        public ActionResult DiscussProject()
        {
            return View(new Lead());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DiscussProject([Bind(Exclude = "Id")]Lead lead)
        {
            if (ModelState.IsValid)
            {
                _leadService.Create(lead);
                return RedirectToAction("LeadConfirmed");
            }
            
            return View(lead);
        }

        public ActionResult LeadConfirmed()
        {
            return View();
        }
    }
}