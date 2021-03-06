﻿using System;
using System.Collections.Generic;
using System.Dynamic;
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

            return GetData(data);
        }

        public ActionResult tab2()
        {
            var data = RouteData.Values["pathInfo"];

            return GetData(data);
        }

        private ActionResult GetData(object pathInfo)
        {
            // ==seq==
            var model = Helper.GetObjectBySeqPathInfo<ViewModel>(pathInfo);
            model.PageIndex++;
            var pagerUrl = Url.UiRouteSeqUrl("Index", "Pagination", model);
            
            // ==pair==
            //var model = Helper.GetObjectByPairUrl<ViewModel>(str);
            //model.PageIndex++;
            //var pagerUrl = Url.ClientRoutePairUrl("Index", "Pagination", model);
            
            string data =
                string.Format(@"tabName:{0}, pageIndex:{1} <br /> <a href=""{2}"">next (pageIndex + 1 = {3})</a>",
                    model.TabName, model.PageIndex, pagerUrl, model.PageIndex++);
            
            Session["htmlData"] = data;
            return Content(data);
        }


        public class ViewModel
        {
            public string TabName { get; set; }
            public int PageIndex { get; set; }
        }
    }
}