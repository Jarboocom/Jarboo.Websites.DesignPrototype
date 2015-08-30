using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Domain.Leads;
using Website.Services;

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


            return View(lead);
        }


    }
}