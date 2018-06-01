using AssemblyInterFace.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyInterFace.Implement
{
    public class PalyService : IPalyService
    {
        public void Paly()
        {
            Console.WriteLine("玩耍");
        }
    }
}
