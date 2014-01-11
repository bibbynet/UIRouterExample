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
            var param = Convert.ToString(RouteData.Values["pathInfo"]);

            var name = param.Replace(@"/", "");

            if (string.IsNullOrEmpty(name))
                return Content(string.Empty);

            return PartialView(name);

            //var html = RenderPartialToString(name, null);
            //@ViewBag.Data = html;
            //return Content(html);
        }
    }
}