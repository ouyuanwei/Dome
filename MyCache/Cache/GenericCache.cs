using MyCache.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Configuration;
using System.Text.RegularExpressions;

namespace MyCache.Cache
{
    public class GenericCache
    {
        private static Dictionary<string, BaseCache> _dicCache = new Dictionary<string, BaseCache>();
        private static readonly string _cacheClearSpanStr = ConfigurationManager.AppSettings["CacheClearSpan"];
        private static int _cacheClearSpan = 60 * 60;//3600s清理一次
        private static object _lock = new object();

        static GenericCache()
        {
            if (!string.IsNullOrEmpty(_cacheClearSpanStr) && Regex.IsMatch(_cacheClearSpanStr, @"\d+"))
            {
                int span = 0;
                if (int.TryParse(_cacheClearSpanStr, out span))
                {
                    _cacheClearSpan = span;
                }
            }
            Task.Run(() =>//启动一个线程自动清理缓存
            {
                while (true)
                {
                    lock (_lock)
                    {
                        List<string> keyList = new List<string>();
                        foreach (var key in _dicCache.Keys)
                        {
                            BaseCache cache = _dicCache[key];
                            if (cache.OverdueTime < DateTime.Now)
                            {
                                keyList.Add(key);
                            }
                        }
                        keyList.ForEach(k => _dicCache.Remove(k));
                    }
                    Thread.Sleep(1000 * _cacheClearSpan);
                }
            });
        }

        public static T GetCache<T>(string key)
        {
            lock (_lock)
            {
                if (ExsitKey(key))
                {
                    var cache = _dicCache[key];
                    if (cache.GetType() != typeof(BaseCache<T>))
                    {
                        throw new Exception("The type of input and inconsistencies in the cache,please check your input Type");
                    }
                    if (cache.OverdueTime > DateTime.Now)
                    {
                        return ((BaseCache<T>)cache).Data;
                    }
                    else
                    {
                        RemoveCache(key);
                    }
                }
                return default(T);
            }
        }
        public static void AddCache<T>(string key, T data, int second = 1000 * 60 * 30)
        {
            lock (_lock)
            {
                if (ExsitKey(key))
                {
                    RemoveCache(key);
                }
                _dicCache.Add(key, new BaseCache<T>
                {
                    Data = data,
                    OverdueTime = DateTime.Now.AddSeconds(second)
                });
            }
        }
        public static void RemoveCache(string key)
        {
            lock (_lock)
            {
                _dicCache.Remove(key);
            }
        }
        public static void RemoveCache(Func<string, bool> func)
        {
            lock (_lock)
            {
                List<string> keyList = new List<string>();
                foreach (var key in _dicCache.Keys)
                {
                    keyList.Add(key);
                }
                keyList.ForEach(k => _dicCache.Remove(k));
            }
        }
        public static bool ExsitKey(string key)
        {
            lock (_lock)
            {
                return _dicCache.ContainsKey(key);
            }
        }
    }
}
