using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AssemblyInterFace.CreateBll;
using AssemblyInterFace.InterFace;


namespace AssemblyInterFace
{
    class Program
    {
        static void Main(string[] args)
        {
            //通过接口反射出实现类(Assembly),并缓存已使用过的接口
            for (int i = 0; i < 10; i++)
            {
                Task.Run(() =>
                {
                    IStudyService study = CreateImplement.ImplementCreate<IStudyService>();
                    study.Study();

                    ISheepService sheep = CreateImplement.ImplementCreate<ISheepService>();
                    sheep.Sheep();

                    IPalyService paly = CreateImplement.ImplementCreate<IPalyService>();
                    paly.Paly();
                });
            }
            Console.ReadKey();
        }
    }
}
