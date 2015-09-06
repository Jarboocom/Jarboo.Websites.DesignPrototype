using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Domain.Leads;
using Services.Services;
using Mandrill;
using Mandrill.Model;


namespace Website.Models.ExtensionMethods
{
    public class MandrillSendExtension
    {
        public static IList<MandrillSendMessageResponse> customSend(object model, MandrillTemplates template)
        {
            var api = new MandrillApi("IRWMe1g1dCTrG6uOZEy7gQ");
            var message = new MandrillMessage();
            message.FromEmail = "info@jarboo.com";
            message.AddTo("lh@jarboo.com");
            message.ReplyTo = "info@jarboo.com";
            foreach (var prop in model.GetType().GetProperties())
            {
                var value = prop.GetValue(model, null);
                if(value != null)
                    message.AddGlobalMergeVars(prop.Name, prop.GetValue(model, null).ToString());
            }
            string templateName = string.Empty;

            switch (template)
            {
                case MandrillTemplates.Lead: templateName = "customer-lead"; break;
                case MandrillTemplates.Invoice: templateName = "customer-invoice"; break;
                default: break;
            }

            if (!string.IsNullOrEmpty(templateName))
            {
                var result = api.Messages.SendTemplate(message, templateName);
                return result;
            }
            return null;
        }
       
    }
    public enum MandrillTemplates
    {
        Lead,
        Invoice
    }

    

}
