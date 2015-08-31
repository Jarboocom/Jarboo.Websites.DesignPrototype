using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services.Domain.Leads;
using Services.Services;

namespace Website.Controllers
{
    public class LeadController : Controller
    {

        private ILeadService _leadService;
        public LeadController()
        {
            _leadService = new LeadService();
        }

        public ActionResult DiscussProject()
        {
            return View(new Lead());
        }

        [HttpPost]
        public ActionResult DiscussProject(Lead lead)
        {
            _leadService.Create(lead);
            
            return RedirectToAction("LeadConfirmed");
        }

        public ActionResult LeadConfirmed()
        {
            return View();
        }


    }
}