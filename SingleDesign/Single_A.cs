using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleDesign
{
    /// <summary>
    /// 单例模式1
    /// </summary>
    class Single_A: IShow
    {
        private static Single_A single = null;
        private static object _lock = new object();
        private Single_A()
        {
            Console.WriteLine("实例化{0}", this.GetType().Name);
        }
        public static Single_A CreateInstance()
        {
            //双重if加lock模式
            if(single==null)
            {
               lock(_lock)
                {
                    if(single==null)
                    {
                        single = new Single_A();
                    }
                }
            }
            return single;
        }

        public void Show()
        {
            Console.WriteLine("this is {0} show",this.GetType().Name);

        }
    }
}
