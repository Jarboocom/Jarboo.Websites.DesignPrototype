using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using log4net;

namespace Services.Services.Caching
{
    public class HttpCacheService
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(HttpCacheService));


        public object GetById(string cacheKey)
        {
            if (ContainsKey(cacheKey))
            {
                return HttpRuntime.Cache[cacheKey];
            }

            logger.Info("Cache key missed: " + cacheKey);
            return null;
        }

        public object Create(string cacheKey, object obj)
        {
            return Create(cacheKey, obj, DateTime.UtcNow.AddHours(5));
        }

        public object Create(string cacheKey, object obj, DateTime expire)
        {
            if (!ContainsKey(cacheKey))
            {
                HttpRuntime.Cache.Insert(cacheKey,
                    obj,
                    null,
                    expire,
                    Cache.NoSlidingExpiration);
            }
            return GetById(cacheKey);
        }

        public void Delete(string cacheKey)
        {
            HttpRuntime.Cache.Remove(cacheKey);
        }

        public void DeleteByContaining(string containing)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            List<string> deleteList = new List<string>();
            var oc = HttpRuntime.Cache;
            // find all cache keys in the system... maybe insane? I don't know lol
            IDictionaryEnumerator en = oc.GetEnumerator();
            while (en.MoveNext())
            {
                var k = en.Key.ToString();
                if (k.Contains(containing))
                {
                    deleteList.Add(k);
                }
            }

            foreach (var del in deleteList)
            {
                Delete(del);
            }


            watch.Stop();
            logger.Info(string.Format("DeleteByContaining containing {0} took {1} ms", containing, watch.ElapsedMilliseconds));
        }


        public bool ContainsKey(string cacheKey)
        {
            return HttpRuntime.Cache[cacheKey] != null;
        }

        public string GetCacheKey(string className, string methodName, string value)
        {
            return string.Format("{0}_{1}_{2}", className, methodName, value);
        }
    }
}
