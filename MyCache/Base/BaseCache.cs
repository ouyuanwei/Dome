using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCache.Base
{
    public class BaseCache
    {
        public DateTime OverdueTime{ set; get; }
    }
    public class BaseCache<T> : BaseCache
    {
        public T Data { set; get; }
        public BaseCache()
        {
            if (typeof(string)== typeof(T))
            {
                this.Data = default(T);
            }
            else
            {
                this.Data = (T)Activator.CreateInstance(typeof(T));
            }
        }
        public BaseCache(T data)
        {
            this.Data = data;
        }
    }
}
