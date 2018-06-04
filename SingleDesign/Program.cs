using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            //SingleDesign :单例模式 ,内存中只实例化一次
            for (int i = 0; i < 10; i++)
            {
                Task.Run(() =>
                {
                    Single_A single_A = Single_A.CreateInstance();
                    Single_B single_B = Single_B.CreateInstance();
                    Single_C single_C = Single_C.CreateInstance();
                    single_A.Show();
                    single_B.Show();
                    single_C.Show();
                });
            }
            Console.ReadKey();
        }
    }
}
