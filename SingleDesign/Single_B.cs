using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleDesign
{
    /// <summary>
    /// 单例模式2
    /// </summary>
    class Single_B : IShow
    {
        private static Single_B single = null;
        private Single_B()
        {
            Console.WriteLine("实例化{0}", this.GetType().Name);
        }
        static Single_B()
        {
            //static构造函数 只调用一次
            single = new Single_B();
        }
        public static Single_B CreateInstance()
        {
            return single;
        }
        public void Show()
        {
            Console.WriteLine("this is {0} show", this.GetType().Name);

        }
    }
}
