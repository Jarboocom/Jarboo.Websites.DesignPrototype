using System.Web.Mvc;
using System.Web.Routing;

namespace Website
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Single case",
                url: "case/{*slug}",
                defaults: new { controller = "Case", action = "Index", slug = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Resource",
                url: "resources/{*slug}",
                defaults: new { controller = "Page", action = "Index", slug = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Services",
                url: "services/{*slug}",
                defaults: new { controller = "Page", action = "Services", slug = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Blog",
                url: "blog/{*slug}",
                defaults: new { controller = "Page", action = "Blog", slug = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

           
            routes.MapRoute(
                name: "Page",
                url: "{controller}/{action}/{slug}",
                defaults: new { controller = "Page", action = "Index" }
            );


        }
    }
}
