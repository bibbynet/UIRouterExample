using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UIRouterExample
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ui-route1",
                url: "{controller}/{action}/r/{p1}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    p1 = UrlParameter.Optional,
                }
            );
            routes.MapRoute(
                name: "ui-route2",
                url: "{controller}/{action}/r/{p1}/{p2}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    p1 = UrlParameter.Optional,
                    p2 = UrlParameter.Optional,
                }
            );
        }
    }
}
