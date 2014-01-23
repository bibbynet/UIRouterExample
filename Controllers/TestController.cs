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
            var param = Convert.ToString(RouteData.Values["pathInfo"]);

            string data = string.Format("category1, param:{0} - {1}", param, DateTime.Now);
            return Content(data);
        }

        public ActionResult PageData2()
        {
            var param = Convert.ToString(RouteData.Values["pathInfo"]);
            
            string data = string.Format("category2, param:{0} - {1}", param, DateTime.Now);
            return Content(data);
        }
    }
}