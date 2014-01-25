using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UIRouterExample.Controllers
{
    public class MultiViewsController : Controller
    {
        //
        // GET: /MultiViews/
        public ActionResult Index()
        {
            return View();
        }
	}
}