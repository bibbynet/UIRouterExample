using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UIRouterExample.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RenderPartial()
        {
            var p1 = Convert.ToString(RouteData.Values["p1"]);
            var p2 = Convert.ToString(RouteData.Values["p2"]);

            var name = string.Format("{0}{1}", p1, p2);

            if (string.IsNullOrEmpty(name))
                return Content(string.Empty);

            return PartialView(name);

            //var html = RenderPartialToString(name, null);
            //@ViewBag.Data = html;
            //return Content(html);
        }
    }
}