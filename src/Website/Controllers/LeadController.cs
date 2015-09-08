using System.Web.Mvc;
using Services.Domain.Leads;
using Services.Services;
using Mandrill;
using Mandrill.Model;
using Website.Models.ExtensionMethods;



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
                //var result = MandrillSendExtension.customSend(lead, MandrillTemplates.Lead);
                Send(lead);
                return RedirectToAction("LeadConfirmed");
            }

            return View(lead);
        }

        public ActionResult LeadConfirmed()
        {
            return View();
        }

        private void Send(Lead model)
        {
            var api = new MandrillApi("IRWMe1g1dCTrG6uOZEy7gQ");
            var message = new MandrillMessage();
            message.Subject = "New lead";
            message.FromEmail = "info@jarboo.com";
            message.AddTo("lh@jarboo.com");
            message.ReplyTo = "info@jarboo.com";
            //supports merge var content as string
            message.AddGlobalMergeVars("Name", model.Name);
            message.AddGlobalMergeVars("LeadStatus", model.LeadStatus.ToString());
            message.AddGlobalMergeVars("DateCreated", model.DateCreated.ToShortDateString());
            message.AddGlobalMergeVars("DateUpdated", model.DateUpdated.ToShortDateString());
            message.AddGlobalMergeVars("EMAIL", model.Email);
            message.AddGlobalMergeVars("Skype", model.Skype);
            message.AddGlobalMergeVars("Phone", model.Phone);
            message.AddGlobalMergeVars("Company", model.Company);
            message.AddGlobalMergeVars("Skype", model.Skype);
            message.AddGlobalMergeVars("ProjectDescription", model.ProjectDescription);
            message.AddGlobalMergeVars("ProjectStart", model.ProjectStart);
            message.AddGlobalMergeVars("ProjectDeadline", model.ProjectDeadline);
            //template should be created
            var result = api.Messages.SendTemplate(message, "jarboo-new-lead");
        }
    }
}

