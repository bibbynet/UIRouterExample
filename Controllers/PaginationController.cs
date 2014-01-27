﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UIRouterExample.Controllers
{
    public class PaginationController : Controller
    {
        //
        // GET: /Main/
        public ActionResult Index()
        {
            dynamic obj = new
            {
                tab1 = new
                {
                    pageIndex = 0,
                    counter = 33
                },
                tab2 = new
                {
                    pageIndex = 0,
                    counter = 51,
                }

            };



            return View(obj);
        }

        public ActionResult tab1()
        {
            var data = RouteData.Values["pathInfo"];

            return GetData(data, "tab1");
        }

        public ActionResult tab2()
        {
            var data = RouteData.Values["pathInfo"];

            return GetData(data, "tab2");
        }

        private ActionResult GetData(object p, string name)
        {
            var currentIndex = Convert.ToInt16(p.ToString().Split('/')[0]);

            string data = string.Format(@"{2}, param:{0} - {1} <br /> <a href=""/Pagination/Index/r/{2}/{3}"">next (pageIndex + 1 = {3})</a>",
                currentIndex, DateTime.Now, name, currentIndex + 1);


            Session["htmlData"] = data;

            return Content(data);
        }
    }
}