using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace System.Web.Mvc
{
    //public class CaseInsensitive : ConventionInjection
    //{
    //    protected override bool Match(ConventionInfo c)
    //    {
    //        return c.SourceProp.Name.ToLower() == c.TargetProp.Name.ToLower();
    //    }
    //}


    public class Helper
    {
        public static T GetObject<T>(string url) where T : new()
        {
            string separator = "/";

            var arr = url.Split(separator.ToCharArray());
            if (arr.Length % 2 != 0)
                throw new Exception("please prepare the string to match pair namne value string");

            string tempName = "";
            var dObj = new Dictionary<string, object>();
            for (var i = 0; i < arr.Length; i++)
            {
                var item = arr[i];
                if (i % 2 == 0)
                {
                    dObj.Add(item, null);
                    tempName = item;
                }
                if (i % 2 == 1)
                {
                    dObj[tempName] = item;
                }
            }

            string jsonStr = JsonConvert.SerializeObject(dObj);
            return JsonConvert.DeserializeObject<T>(jsonStr);
        }
    }


    public static class Extensions
    {
        public static string ClientRouteUrl(this UrlHelper urlHelper, string actionName, string controllerName, object obj)
        {
            //var serverUrl = urlHelper.Action(actionName, controllerName);

            var jsonStr = JsonConvert.SerializeObject(obj);
            var dic = JsonConvert.DeserializeObject<IDictionary<string, string>>(jsonStr);

            var list = new List<string>();
            foreach (var item in dic)
            {
                var k = HttpUtility.UrlEncode(item.Key);
                var v = HttpUtility.UrlEncode(item.Value);
                list.Add(string.Concat(k, "/", v));
            }

            var objUrl = string.Join("/", list.ToArray());

            return string.Format("/{0}/{1}/r/{2}", controllerName, actionName, objUrl).ToLower();
        }

    }
}