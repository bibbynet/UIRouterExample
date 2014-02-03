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
                name: "ui-route",
                url: "{controller}/r/{*pathInfo}",
                defaults: new
                {
                    action = "Index"
                }
            );

            routes.MapRoute(
                name: "ui-route1",
                url: "{controller}/{action}/r/{*pathInfo}"
            );
        }
    }
}
