using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Helpers
{
    public static class HtmlHelpers
    {
        public static HtmlString IsActive(this HtmlHelper helper, string action, string controller)
        {
            string cAction = helper.ViewContext.RouteData.Values["action"] as string ?? "";
            string cController = helper.ViewContext.RouteData.Values["controller"] as string ?? "";
            return cAction.Equals(action, StringComparison.InvariantCultureIgnoreCase)
                   && cController.Equals(controller, StringComparison.InvariantCultureIgnoreCase)
                ? new HtmlString("active")
                : new HtmlString("");
        }
    }
}