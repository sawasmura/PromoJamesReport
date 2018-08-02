using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PromoProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            
            routes.MapRoute(
                name: "News",
                url: "chi-tiet/{metaList}-{id}",
                defaults: new { controller = "News", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "PromoProject.Controllers" }
            );
            routes.MapRoute(
                name: "Category",
                url: "chu-de/{id}",
                defaults: new { controller = "Category", action = "Category", id = UrlParameter.Optional },
                namespaces: new[] { "PromoProject.Controllers" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces:new []{"PromoProject.Controllers"}
            );
            
           /* routes.MapRoute(
                name: "Category Category",
                url: "chi-tiet/style-{id}",
                defaults: new { controller = "News", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "PromoProject.Controllers" }
            );*/
        }
    }
}
