using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleDesign
{
    class Single_C : IShow
    {
        private static Single_C single = new Single_C();
        private Single_C()
        {
            Console.WriteLine("实例化{0}", this.GetType().Name);
        }
        public static Single_C CreateInstance()
        {
            return single;
        }
        public void Show()
        {
            Console.WriteLine("this is {0} show", this.GetType().Name);

        }
    }
}
