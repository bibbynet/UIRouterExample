using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace System.Web.Mvc
{
    public class Helper
    {
        public static T GetObjectByPairPathInfo<T>(object pathInfo) where T : new()
        {
            string separator = "/";

            string info = pathInfo.ToString();
            var arr = info.Split(separator.ToCharArray());
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

        public static T GetObjectBySeqPathInfo<T>(object pathInfo) where T : new()
        {
            string separator = "/";

            string info = pathInfo.ToString();
            var arr = info.Split(separator.ToCharArray());

            var tStr = JsonConvert.SerializeObject(new T());
            var tObj = (JsonConvert.DeserializeObject(tStr) as JObject);

            var i = 0;
            var dic = new Dictionary<string, object>();
            foreach (var item in tObj)
            {
                if (i >= arr.Length)
                    break;

                dic.Add(item.Key, arr[i]);
                i++;
            }

            foreach (var item in dic)
            {
                tObj.Remove(item.Key);
                tObj.Add(new JProperty(item.Key, item.Value));
            }

            var tStr2 = JsonConvert.SerializeObject(tObj);
            try
            {
                return JsonConvert.DeserializeObject<T>(tStr2);
            }
            catch (Exception ex)
            {
                throw new Exception("convert data to type is fail", ex);
            }
        }


    }


    public static class Extensions
    {
        public static string UiRoutePairUrl(this UrlHelper urlHelper, string actionName, string controllerName, object obj)
        {
            var serverUrl = urlHelper.Action(actionName, controllerName);

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

            return string.Format("{0}/r/{1}", serverUrl, objUrl).ToLower();
        }

        public static string UiRouteSeqUrl(this UrlHelper urlHelper, string actionName, string controllerName, object obj)
        {
            var serverUrl = urlHelper.Action(actionName, controllerName);

            var jsonStr = JsonConvert.SerializeObject(obj);
            var dic = JsonConvert.DeserializeObject<IDictionary<string, string>>(jsonStr);

            var list = new List<string>();
            foreach (var item in dic)
            {
                var v = HttpUtility.UrlEncode(item.Value);
                list.Add(v);
            }

            var objUrl = string.Join("/", list.ToArray());

            return string.Format("{0}/r/{1}", serverUrl, objUrl).ToLower();
        }

    }
}