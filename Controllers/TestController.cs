using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UIRouterExample.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Main/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PageData1()
        {
            var data = RouteData.Values["pathInfo"];

            return GetData(data, "category1");
        }

        public ActionResult PageData2()
        {
            var data = RouteData.Values["pathInfo"];

            return GetData(data, "category2");
        }

        private ActionResult GetData(object p, string name)
        {
            var currentIndex = Convert.ToInt16(p.ToString().Split('/')[0]);

            string data = string.Format(@"{2}, param:{0} - {1} <br /> <a ui-sref=""{2}({{pageIndex:{3}}})"">next</a>",
                currentIndex, DateTime.Now, name, currentIndex+1);

            
            Session["htmlData"] = data;

            return Content(data);
        }
    }
}